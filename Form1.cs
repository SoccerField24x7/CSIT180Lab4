using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherStation.BL;

namespace WeatherStation
{
    public partial class Form1 : Form
    {
        private BusinessLogic helper;

        public Form1()
        {
            InitializeComponent();
            this.helper = new BusinessLogic();
            this.AddFormSelectionValues();            
        }

        private void AddFormSelectionValues()
        {
            /* get the form options */
            var highTemps = this.helper.GetHighTemperatureValues();
            var lowTemps = this.helper.GetLowTemperatureValues();
            var windSpeeds = this.helper.GetWindSpeedValues();
            var skyConditions = this.helper.GetSkyConditions();

            /* now add them to the form */            
            foreach (int high in highTemps)
            {
                cmbHighs.Items.Add(high);
            }

            foreach (int low in lowTemps)
            {
                cmbLows.Items.Add(low);
            }

            foreach (int speed in windSpeeds)
            {
                cmbSpeeds.Items.Add(speed);
            }

            foreach (string cond in skyConditions)
            {
                cmbConditions.Items.Add(cond);
            }
        }

        private void cmbHighs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsAllSelected())
            {
                btnResults.Enabled = true;
            }
        }

        private void cmbLows_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (IsAllSelected())
            {
                btnResults.Enabled = true;
            }
        }

        private void cmbSpeeds_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsAllSelected())
            {
                btnResults.Enabled = true;
            }
        }

        private void cmbConditions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsAllSelected())
            {
                btnResults.Enabled = true;
            }
        }

        /// <summary>
        /// Checks to see if all of the select boxes have been filled.  If so, enable the submit button
        /// </summary>
        /// <returns></returns>
        private bool IsAllSelected()
        {
            if (cmbHighs.SelectedItem == null)
            {
                return false;
            }

            if (cmbLows.SelectedItem == null)
            {
                return false;
            }

            if (cmbSpeeds.SelectedItem == null)
            {
                return false;
            }

            if (cmbConditions.SelectedItem == null)
            {
                return false;
            }

            return true;
        }
        
        /// <summary>
        /// Performs transformations and calculations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResults_Click(object sender, EventArgs e)
        {
            /* assign the selected values to the form for viewing */
            lblHigh.Text = cmbHighs.SelectedItem.ToString();
            lblLow.Text = cmbLows.SelectedItem.ToString();
            lblSpeed.Text = cmbSpeeds.SelectedItem.ToString();

            /* assign the selected values to the bl object */
            this.helper.HighTemperature = int.Parse(lblHigh.Text);
            this.helper.LowTemperature = int.Parse(lblLow.Text);
            this.helper.WindSpeed = int.Parse(lblSpeed.Text);

            /* get the selected skycondition as string */
            string skyCond = cmbConditions.SelectedItem.ToString();

            /* reverse the string to the enumeration */
            var skyEnum = (SkyConditions)Enum.Parse(typeof(SkyConditions), skyCond);

            /* get the image name */
            string imageName = this.helper.GetSkyImageName(skyEnum);

            /* dynamically create the image from the file system */
            var img = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\..\\..\\assets\\" + imageName);

            /* assign image resource to the the control */
            pbxSky.Image = img;

            /* calc and assign the windchill */
            var windChill = this.helper.CalculateWindChill();
            lblWindChill.Text = windChill == 9999 ? "N/A" : Math.Round(windChill, 0).ToString(); // 9999 means it was too warm, or no wind
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
