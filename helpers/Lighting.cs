using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightingCalculator.database;
using System.Windows.Forms;


using Autodesk.AutoCAD.DatabaseServices;

namespace LightingCalculator.helpers
{
    public class Lighting
    {
        private DBMain database = new DBMain();
        public double CalculateRoomIndex(double Width, double Length, double CeilingHeight, double WorkingPlaneHeight)
        {
            // Room Index(k) = a*b / hk (a+b)

            double hk = CeilingHeight - WorkingPlaneHeight; // for calculating lux at working plane height

            double area = Width * Length;
            double denominator = hk * (Width + Length);

            double RoomIndex = area / denominator;
            return RoomIndex;
        }

        public double CalculateUtilisationFactor(double CeilingFactor, double WallFactor, double FloorFactor, double roomIndex)
        {
                //double uf = 1.12862;
                //double denom = (0.0261234 * float.Parse(RoomIndexTxtBox.Text));
                //uf = Math.Round(uf, 3);

                //UtilisationFactorTxtBox.Text = uf.ToString();

                // room index min = 0.75 max = 5, steps 0.75, 1, 1.25, 1.5, 2, 2.5, 3, 4, 5
                if (roomIndex < 0.75)
                {
                    roomIndex = 0.75; // min case
                }

                if (roomIndex > 0.75 && roomIndex <= 1)
                {
                    roomIndex = 1; // round up to 1
                }

                if (roomIndex > 1 && roomIndex <= 1.25)
                {
                    roomIndex = 1.25; // round to 1.25
                }

                if (roomIndex > 1.25 && roomIndex <= 1.5)
                {
                    roomIndex = 1.5; // round to 1.5
                }

                if (roomIndex > 1.5 && roomIndex <= 2)
                {
                    roomIndex = 2; // round to 2
                }

                if (roomIndex > 2 && roomIndex <= 2.5)
                {
                    roomIndex = 2.5; // round to 2.5
                }

                if (roomIndex > 2.5 && roomIndex <= 3)
                {
                    roomIndex = 3; // round to 3
                }

                if (roomIndex > 3 && roomIndex <= 4)
                {
                    roomIndex = 4; // round to 4
                }

                if (roomIndex > 4 && roomIndex <= 5)
                {
                    roomIndex = 5; // round to 5
                }

                if (roomIndex > 5)
                {
                    roomIndex = 5; // max case
                }

                return database.findUtilisationFactor(CeilingFactor, WallFactor, FloorFactor, roomIndex);
        }

        private calculatedLightingOption calculateCeilingOption(double area, double utilisationFactor, double maintenanceFactor)
        {
            calculatedLightingOption output = new calculatedLightingOption();
            // N = Lux * Area / Lumens * uf * mf (total fittings)
            // Lux = N * lumens * uf * mf / Area (average lux)
            // E = I / d^2 (point directly under)

            return output;
        }

    }

    public class Light
    {
        public string ProductCode { get; set; }
        public double CircuitWattage { get; set; }
        public double LumenOutput { get; set; }
        public string LightDescription { get; set; }
    }

    public class LightingFormFactors
    {
        public double CeilingFactor { get; set; }

        public double WallFactor {get; set; }

        public double FloorFactor {get; set; }

        public double CeilingHeight {get; set; }

        public double LightHeight {get; set; }

        public double WorkingPlaneHeight {get; set; }

        public double TargetLux { get; set; }

        public double MaintenanceFactor { get; set; }
    }

    public class calculatedLightingOption
    {
        public int CeilingNum { get; set; }

        public ObjectId ceilingObjId { get; set; }

        public string FittingName { get; set; }

        public double NumFittings { get; set; }

        public double PointLux { get; set; }

        public double AvgLux { get; set; }

        public bool OptionSelected { get; set; }

    }
}
