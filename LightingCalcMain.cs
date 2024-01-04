using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Import dependencies
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;

using LightingCalculator.helpers;

namespace LightingCalculator
{
    public class LightingCalcMain
    {
        [CommandMethod("LuxCalc", CommandFlags.UsePickSet)]
        public void LuxCalc()
        {
            MainForm mf = new MainForm();
            mf.Show();
        }

        //static void Main()
        //{
        //    System.Windows.Forms.Application.Run(new MainForm());
        //}
    }
}
