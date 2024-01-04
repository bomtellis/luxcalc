using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LightingCalculator.helpers;

using Autodesk.AutoCAD.DatabaseServices;

namespace LightingCalculator
{
    public partial class LightingOptions : Form
    {
        private List<calculatedLightingOption> DataViewItems = new List<calculatedLightingOption>();
        private AC ac = new AC();

        public LightingOptions(List<calculatedLightingOption> computedResults)
        {
            InitializeComponent();
            fillDataView(computedResults);
        }

        public void fillDataView(List<calculatedLightingOption> computedResults)
        {
            foreach (calculatedLightingOption item in computedResults)
            {
                DataViewItems.Add(item);
            }
            
            // hide the ceilingObjId Column from view
            //this.dataGridView1.Columns["id"].Visible = false;

            //DataViewItems.Add(new calculatedLightingOption() { 
            //    CeilingNum = 1,
            //    FittingName = "IMPR65 L45",
            //    NumFittings = 2,
            //    PointLux = 450,
            //    AvgLux = 250,
            //    OptionSelected = false
            //});

            dataGridView1.DataSource = DataViewItems;
        }

        private void AllCADBtn_Click(object sender, EventArgs e)
        {
            foreach(calculatedLightingOption calc in DataViewItems)
            {
                if(calc.OptionSelected == true)
                {
                    ac.addTextToDrawing(calc);
                    this.Close();
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // if user clicks top row unhandled error is thrown
            System.Diagnostics.Debug.Write(e.RowIndex);
            if(e.RowIndex == -1)
            {
                
            }
            else
            {
                ObjectId ceilingObjId = DataViewItems[e.RowIndex].ceilingObjId;
                ac.HighlightCeiling(ceilingObjId);

                Task.Delay(5000).ContinueWith(t => ac.UnhighlightCeiling(ceilingObjId));
            }
        }
    }
}
