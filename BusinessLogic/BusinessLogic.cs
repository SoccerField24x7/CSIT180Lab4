using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation.BL
{
    public class BusinessLogic : IBusinessLogic
    {
        public const int MEASUREMENT_INTERVAL = 5;

        public int LowTemperature { get; set; }
        public int HighTemperature { get; set; }
        public double WindSpeed { get; set; }
        public string WeatherCondition { get; set; }

        public List<int> GetWindSpeedValues(int high = 30)
        {
            List<int> speeds = new List<int>();

            for (int i=0; i <= high; i += MEASUREMENT_INTERVAL)
            {
                speeds.Add(i);
            }

            return speeds;
        }

        public List<int> GetLowTemperatureValues(int low = -15, int high = 50)
        {
            List<int> temps = new List<int>();

            for (int i = low; i <= high; i += MEASUREMENT_INTERVAL)
            {
                temps.Add(i);
            }

            return temps;
        }

        public List<int> GetHighTemperatureValues(int low = 50, int high = 100)
        {
            List<int> temps = new List<int>();

            for (int i = low; i <= high; i += MEASUREMENT_INTERVAL)
            {
                temps.Add(i);
            }

            return temps;
        }

        public List<string> GetSkyConditions()
        {
            List<string> conditions = new List<string>();

            foreach (string condition in (string[]) Enum.GetNames(typeof(SkyConditions)))
            {
                conditions.Add(condition);
            }

            return conditions;
        }

        public double CalculateWindChill()
        {
            // According to the NOAA, windchill can only be calculated when the temperature is below 70 degrees F
            if (this.HighTemperature >= 70)
            {
                return 9999;
            }

            //Wind Chill Formula = 35.74 + 0.6215T – 35.75(V ^ 0.16) + 0.4275T(V ^ 0.16)
            return 35.74 + 0.6215 * this.HighTemperature - 35.75 * (Math.Pow(this.WindSpeed , 0.16)) + 0.4275 * this.HighTemperature * (Math.Pow(this.WindSpeed, 0.16));
        }

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
