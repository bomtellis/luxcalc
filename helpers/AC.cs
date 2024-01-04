using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Import Autodesk Autocad References
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Colors;

namespace LightingCalculator.helpers
{
    public class AC
    {
        private Lighting ltg = new Lighting();
        public class ceiling: IEquatable<ceiling>
        {
            public double width { get; set; }
            public double length { get; set; }

            public double area { get; set; }

            public ObjectId id { get; set; }

            public bool Equals(ceiling other)
            {
                if (other == null) return false;
                return (this.id.Equals(other.id));
            }
        }

        public List<ceiling> getData (List<ObjectId> objID)
        {
            // Get the current document and database
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            List<ceiling> outputList = new List<ceiling> { };

            // Start a transaction
            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                foreach (ObjectId objId in objID)
                {
                    var pline = (Polyline)acTrans.GetObject(objId, OpenMode.ForRead);

                    double xMin = 0, yMin = 0, xMax = 0, yMax = 0;
                    int totalVertices = pline.NumberOfVertices;

                    for (int i = 0; i < totalVertices; i++)
                    {
                        if (i == 0)
                        {
                            // set first vertex as reference point
                            Array vertex = pline.GetPoint2dAt(i).ToArray();
                            xMin = (double)vertex.GetValue(0);
                            yMin = (double)vertex.GetValue(1);
                            xMax = (double)vertex.GetValue(0);
                            yMax = (double)vertex.GetValue(1);
                        }
                        else
                        {
                            Array vertex = pline.GetPoint2dAt(i).ToArray();

                            var xCoord = (double)vertex.GetValue(0);
                            var yCoord = (double)vertex.GetValue(1);

                            if (xCoord < xMin)
                            {
                                xMin = xCoord;
                            }

                            if (yCoord < yMin)
                            {
                                yMin = yCoord;
                            }

                            if (xCoord > xMax)
                            {
                                xMax = xCoord;
                            }

                            if (yCoord > yMax)
                            {
                                yMax = yCoord;
                            }
                        }

                    }

                    double width = (xMax - xMin) / 1000;
                    double length = (yMax - yMin) / 1000;
                    double area = width * length;
                    

                    ceiling PolylineCeiling = new ceiling() { 
                        id = objId,
                        width = width,
                        length = length,
                        area = area
                    };

                    outputList.Add(PolylineCeiling);
                }
                // Save the new object to the database
                acTrans.Commit();
                // Dispose of the transaction    
            }
            return outputList;
        }

        public List<ceiling> selectPolylines()
        {
            List<ObjectId> polylineObjIds = new List<ObjectId>();

            Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            // Request for objects to be selected in the drawing area
            var options = new PromptSelectionOptions();
            //options. ("\n Selected object(s) are not polylines");
            //options.AddAllowedClass(typeof(Polyline), true);

            PromptSelectionResult acSSPrompt = acDoc.Editor.GetSelection(options);

            // If the prompt status is OK, objects were selected
            if (acSSPrompt.Status == PromptStatus.OK)
            {
                SelectionSet acSSet = acSSPrompt.Value;

                // Step through the objects in the selection set
                foreach (SelectedObject acSSObj in acSSet)
                {
                    // Check to make sure a valid SelectedObject object was returned
                    if (acSSObj != null)
                    {
                        var objId = acSSObj.ObjectId;
                        polylineObjIds.Add(objId);
                    }
                }
            }

            List<ceiling> ceilings = this.getData(polylineObjIds);

            return ceilings;
        }

        // Adds MText object with all parameters listed in the window for adding into the center of the ceiling.
        // Creates new layer or checks for existing to add to so it can be hidden/frozen later on.
        public void addTextToDrawing(calculatedLightingOption calcOption)
        {
            ObjectId ceilingObjId = calcOption.ceilingObjId;
            string MTextContents = "Fitting: " + calcOption.FittingName + "\n" +
                                    "Qty: " + calcOption.NumFittings + "\n" +
                                    "Lux: " + Math.Round(calcOption.AvgLux);

            // lookup polyline to find center
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;

            // Lock the document up for a while.
            using (DocumentLock DocLock = doc.LockDocument())
            {
                string LayerName = "LuxCalc - Results";

                using (var t = db.TransactionManager.StartTransaction())
                {
                    LayerTable LayTable;
                    LayTable = (LayerTable)t.GetObject(db.LayerTableId, OpenMode.ForRead);

                    // check if the layer already exists
                    if (LayTable.Has(LayerName) == false)
                    {
                        // new layer needed
                        using (LayerTableRecord LayTableRecord = new LayerTableRecord())
                        {
                            // assign colour and name to layer
                            // special case white - on model - black on paper
                            LayTableRecord.Color = Color.FromColorIndex(ColorMethod.ByAci, 0);
                            LayTableRecord.Name = LayerName;

                            // make table writable
                            LayTable.UpgradeOpen();
                            //LayTable = (LayerTable)t.GetObject(db.LayerTableId, OpenMode.ForWrite);
                            // Inser the new layer to the Table
                            LayTable.Add(LayTableRecord);
                            t.AddNewlyCreatedDBObject(LayTableRecord, true); // true = add false = remove
                                                                             // Finish and downgrade to open only
                            LayTable.DowngradeOpen();
                        }
                    }

                    // set current layer to our layer.
                    db.Clayer = LayTable[LayerName];

                    var pline = (Polyline)t.GetObject(ceilingObjId, OpenMode.ForRead);
                    Point2d insertionPoint = GetPolylineCentroidByRegion(pline);

                    // open the block table
                    BlockTable BlkTable = (BlockTable)t.GetObject(db.BlockTableId, OpenMode.ForRead);

                    // create new block table record in the block table ModelSpace
                    BlockTableRecord BlkTableRecord = (BlockTableRecord)t.GetObject(BlkTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                    // create a multiline text object
                    using (MText cMText = new MText())
                    {
                        cMText.Location = new Point3d(insertionPoint.X, insertionPoint.Y, 0);
                        cMText.TextHeight = 200;
                        cMText.Width = 2500;
                        cMText.Attachment = AttachmentPoint.MiddleCenter;
                        cMText.Contents = MTextContents;

                        // add the MText to the new block table record
                        BlkTableRecord.AppendEntity(cMText);
                        // add to DB
                        t.AddNewlyCreatedDBObject(cMText, true);
                    }

                    // close out the transaction
                    t.Commit();
                }
            }


            
        }

        public static Point2d GetPolylineCentroidByRegion(Polyline pline)
        {
            var curves = new DBObjectCollection();
            curves.Add(pline);
            var regions = Region.CreateFromCurves(curves);
            using (var region = (Region)regions[0])
            {
                var origin = Point3d.Origin;
                var xAxis = Vector3d.XAxis;
                var yAxis = Vector3d.YAxis;
                var props = region.AreaProperties(ref origin, ref xAxis, ref yAxis);
                return props.Centroid;
            }
        }

        public void HighlightCeiling(ObjectId ceilingObjId)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;

            using(var docLock = doc.LockDocument())
            {
                using (var t = db.TransactionManager.StartTransaction())
                {
                    Entity pline = (Entity)t.GetObject(ceilingObjId, OpenMode.ForWrite);
                    pline.Color = Color.FromColorIndex(ColorMethod.ByAci, 6); // Magenta
                    t.Commit();
                }
            }
        }

        public void UnhighlightCeiling(ObjectId ceilingObjId)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;

            using (var docLock = doc.LockDocument())
            {
                using (var t = db.TransactionManager.StartTransaction())
                {
                    Entity pline = (Entity)t.GetObject(ceilingObjId, OpenMode.ForWrite);
                    pline.Color = Color.FromColorIndex(ColorMethod.ByAci, 256); // ByLayer
                    t.Commit();
                }
            }
        }
    }
}
