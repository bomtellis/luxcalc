using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using LightingCalculator.helpers;
using LightingCalculator.database;

namespace LightingCalculator
{
    public partial class MainForm : Form
    {
        private DBMain db = new DBMain();
        private List<string> lights;
        private List<string> originalList;
        private AC ac = new AC();
        private Lighting ltg = new Lighting();

        public MainForm()
        {
            InitializeComponent();
            lights = db.lightList();
            originalList = db.lightList();
            listBox1.DataSource = lights;
            CADBtn.Enabled = false;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                var selectedItemText = listBox1.SelectedItem.ToString();
                var selectedItemIndex = listBox1.SelectedIndex;
                if (selectedItemIndex != -1)
                {
                    if (lights != null)
                    {
                        listBox2.Items.Add(selectedItemText);
                        lights.RemoveAt(selectedItemIndex);
                    }
                }
                Databinding();
            }
            if(listBox2.Items != null)
            {
                CADBtn.Enabled = true;
            }
        }

        public void Databinding()
        {
            listBox1.DataSource = null;
            lights = lights.OrderBy(i => originalList.IndexOf(i)).ToList();
            listBox1.DataSource = lights;

            if(listBox2.Items.Count == 0)
            {
                CADBtn.Enabled = false;
            }
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if(listBox2.SelectedItem != null)
            {
                var selectedItemText = listBox2.SelectedItem.ToString();
                var selectedItemIndex = listBox2.SelectedIndex;

                lights.Add(selectedItemText);
                listBox2.Items.RemoveAt(listBox2.Items.IndexOf(listBox2.SelectedItem));
                Databinding();
            }
        }

        private LightingFormFactors GetFactorsFromForm()
        {
            LightingFormFactors output = new LightingFormFactors()
            {
                CeilingFactor = double.Parse(this.CeilingFactorCombo.Text.ToString()),
                WallFactor = double.Parse(this.WallFactorCombo.Text.ToString()),
                FloorFactor = double.Parse(this.FloorFactorCombo.Text.ToString()),
                CeilingHeight = double.Parse(this.CeilingHeightTxtBox.Text.ToString()),
                LightHeight = double.Parse(this.LightHeightTxtBox.Text.ToString()),
                WorkingPlaneHeight = double.Parse(this.WorkingPlaneHeightTxtBox.Text.ToString()),
                TargetLux = double.Parse(this.TargetLuxTxtBox.Text.ToString()),
                MaintenanceFactor = double.Parse(this.MaintenanceFactorTxtBox.Text.ToString())
            };

            return output;
        }

        private void CADBtn_Click(object sender, EventArgs e)
        {
            List<string> output = new List<string>(); // output list of all product codes for lights

            foreach(var item in listBox2.Items)
            {
                output.Add(item.ToString());
            }

            List<Light> lights = new List<Light>();
            lights = db.lightAndLux(output);
           
            this.Hide(); // hide this form

            LightingFormFactors formFactors = GetFactorsFromForm();

            List<AC.ceiling> ceilings = ac.selectPolylines(); // select all polylines to make calculations for

            List<calculatedLightingOption> ComputedOutput = new List<calculatedLightingOption>();

            int ceilingIndex = 1;

            foreach (AC.ceiling Ceiling in ceilings)
            {
                // calculate the utilisation factor and room index
                // room index
                double roomIndex = ltg.CalculateRoomIndex(Ceiling.width, Ceiling.length, formFactors.CeilingHeight, formFactors.WorkingPlaneHeight);

                // utilisation factor
                double utilisationFactor = ltg.CalculateUtilisationFactor(formFactors.CeilingFactor, formFactors.WallFactor, formFactors.FloorFactor, roomIndex);

                foreach (Light light in lights)
                {
                    // check with each light selected what parameters will meet the input from the first form
                    double numFittings = formFactors.TargetLux * Ceiling.area / (light.LumenOutput * formFactors.MaintenanceFactor * utilisationFactor); // rounded up to next whole number
                    double SteradianAngle = 1.84030236902; //2 * Math.PI * (1 - Math.Cos(90 / 2));
                    double pointLux = (light.LumenOutput / SteradianAngle) / Math.Pow((formFactors.CeilingHeight - formFactors.WorkingPlaneHeight), 2); // in lux at working plane 90 degrees


                    double averageLux = Math.Ceiling(numFittings) * light.LumenOutput * utilisationFactor * formFactors.MaintenanceFactor / Ceiling.area; // calculated from the number of fittings stated above

                    ComputedOutput.Add(new calculatedLightingOption()
                    {
                        ceilingObjId = Ceiling.id,
                        CeilingNum = ceilingIndex,
                        FittingName = light.ProductCode,
                        NumFittings = Math.Ceiling(numFittings),
                        PointLux = pointLux,
                        AvgLux = averageLux,
                        OptionSelected = false
                    });
                }

                ceilingIndex++;
            }

            LightingOptions ltgForm = new LightingOptions(ComputedOutput);
            ltgForm.Show();

            Close();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                var selectedItemText = listBox1.SelectedItem.ToString();
                var selectedItemIndex = listBox1.SelectedIndex;
                if (selectedItemIndex != -1)
                {
                    if (lights != null)
                    {
                        listBox2.Items.Add(selectedItemText);
                        lights.RemoveAt(selectedItemIndex);
                    }
                }
                Databinding();
            }
            if (listBox2.Items != null)
            {
                CADBtn.Enabled = true;
            }
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                var selectedItemText = listBox2.SelectedItem.ToString();
                var selectedItemIndex = listBox2.SelectedIndex;

                lights.Add(selectedItemText);
                listBox2.Items.RemoveAt(listBox2.Items.IndexOf(listBox2.SelectedItem));
                Databinding();
            }
        }

        //private void ListBox1_Dbl_Click(object sender, EvenMouseEventArgs e)
        //{
        //    int index = this.listBox1.IndexFromPoint(e.Location);
        //    if(index != System.Windows.Forms.ListBox.NoMatches)
        //    {
        //        MessageBox.Show(index.ToString());
        //    }

        //}
        //private void ListBox2_Dbl_Click(object sender, MouseEventArgs e)
        //{
        //    int index = this.listBox1.IndexFromPoint(e.Location);
        //    if (index != System.Windows.Forms.ListBox.NoMatches)
        //    {
        //        MessageBox.Show(index.ToString());
        //    }

        //}
    }
}
