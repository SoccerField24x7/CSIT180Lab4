using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation.BL
{
    interface IBusinessLogic
    {
        int HighTemperature { get; set; }
        int LowTemperature { get; set; }
        double WindSpeed { get; set; }
        string WeatherCondition { get; set; }
        double CalculateWindChill();
        List<int> GetHighTemperatureValues(int low = 50, int high = 100);
        List<int> GetLowTemperatureValues(int low = -15, int high = 50);
        List<int> GetWindSpeedValues(int high = 30);
        List<string> GetSkyConditions();
        string GetSkyImageName(SkyConditions sky);
    }
}
