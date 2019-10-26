using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation.BusinessLogic
{
    interface IBusinessLogic
    {
        List<int> GetHighTemperatureValues(int low = 50, int high = 100);
        List<int> GetLowTemperatureValues(int low = -15, int high = 50);
        List<int> GetWindChillValues();
        List<string> GetSkyConditions();
    }
}
