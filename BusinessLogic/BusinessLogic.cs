using System;
using System.Collections.Generic;

namespace WeatherStation.BL
{
    public class BusinessLogic : IBusinessLogic
    {
        /* constant to represent the interval for the selection values */
        public const int MEASUREMENT_INTERVAL = 5;

        public int LowTemperature { get; set; }
        public int HighTemperature { get; set; }
        public double WindSpeed { get; set; }
        public string WeatherCondition { get; set; }

        /// <summary>
        /// Creates the wind speed values based on the passed in high water mark in 5 mph increments
        /// </summary>
        /// <param name="high"></param>
        /// <returns>A list containing the windspeeds</returns>
        public List<int> GetWindSpeedValues(int high = 30)
        {
            List<int> speeds = new List<int>();

            for (int i=0; i <= high; i += MEASUREMENT_INTERVAL)
            {
                speeds.Add(i);
            }

            return speeds;
        }

        /// <summary>
        /// Creates the low temperatures based on the supplied parameters in 5 degree increments
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns>List containing low temperatures</returns>
        public List<int> GetLowTemperatureValues(int low = -15, int high = 50)
        {
            List<int> temps = new List<int>();

            for (int i = low; i <= high; i += MEASUREMENT_INTERVAL)
            {
                temps.Add(i);
            }

            return temps;
        }

        /// <summary>
        /// Creates the high temperatures based on the supplied parameters in 5 degree increments
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns>List containing high temperature values</returns>
        public List<int> GetHighTemperatureValues(int low = 50, int high = 100)
        {
            List<int> temps = new List<int>();

            for (int i = low; i <= high; i += MEASUREMENT_INTERVAL)
            {
                temps.Add(i);
            }

            return temps;
        }

        /// <summary>
        /// Converts the enumeration descriptions of the sky conditions
        /// </summary>
        /// <returns>List of sky conditon descriptions</returns>
        public List<string> GetSkyConditions()
        {
            List<string> conditions = new List<string>();

            foreach (string condition in (string[]) Enum.GetNames(typeof(SkyConditions)))
            {
                conditions.Add(condition);
            }

            return conditions;
        }

        /// <summary>
        /// Generates the wind chill temperature based on low temperature below 70 degrees and wind speeds above 2 mph
        /// </summary>
        /// <returns>wind chill temperature</returns>
        public double CalculateWindChill()
        {
            // According to the NOAA, windchill can only be calculated when the temperature is below 70 degrees F and Windspeed < 3 mph
            if (this.LowTemperature >= 70 || this.WindSpeed < 3)
            {
                return 9999;
            }

            //Wind Chill Formula = 35.74 + 0.6215T – 35.75(V ^ 0.16) + 0.4275T(V ^ 0.16)
            return 35.74 + 0.6215 * this.LowTemperature - 35.75 * (Math.Pow(this.WindSpeed , 0.16)) + 0.4275 * this.LowTemperature * (Math.Pow(this.WindSpeed, 0.16));
        }

        /// <summary>
        /// Converts the Sky Conditions enum into the filename representing the weather conditions
        /// </summary>
        /// <param name="sky"></param>
        /// <returns>string containing the image name</returns>
        public string GetSkyImageName(SkyConditions sky)
        {
            string fileName;
            switch (sky)
            {
                case SkyConditions.Clear:
                    fileName = "clear.jpg";
                    break;
                case SkyConditions.Cloudy:
                    fileName = "cloudy.jpg";
                    break;
                case SkyConditions.PartlyCloudy:
                    fileName = "partlycloudy.jpg";
                    break;
                case SkyConditions.Rain:
                case SkyConditions.Snow:
                    fileName = "rain.jpg";
                    break;
                default:
                    fileName = "clear.jpg";
                    break;
            }

            return fileName;
        }
    }
}
