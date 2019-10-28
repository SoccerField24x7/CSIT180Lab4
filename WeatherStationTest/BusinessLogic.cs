using NUnit.Framework;
using System.Collections.Generic;
using WeatherStation.BL;

namespace WeatherStation.BLTests
{
    public class BLTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WindChillSuccess()
        {
            BusinessLogic bl = new BusinessLogic();

            bl.LowTemperature = 50;
            bl.WindSpeed = 20;

            var result = bl.CalculateWindChill();

            Assert.AreEqual(result, 43.599788069758056);
        }

        [Test]
        public void TempTooHighFails()
        {
            BusinessLogic bl = new BusinessLogic();

            bl.LowTemperature = 70;
            bl.WindSpeed = 20;

            Assert.AreEqual(bl.CalculateWindChill(), 9999);
        }

        [Test]
        public void CloudyImageIsCorrect()
        {
            BusinessLogic bl = new BusinessLogic();
            var img = bl.GetSkyImageName(SkyConditions.Cloudy);

            Assert.AreEqual(img, "cloudy.jpg");
        }

        [Test]
        public void CorrectNumberOfHighTempOptions()
        {
            BusinessLogic bl = new BusinessLogic();
            var options = bl.GetHighTemperatureValues();

            Assert.AreEqual(options.Count, 11);
        }

        [Test]
        public void SkyConditionsCountCorrect()
        {
            BusinessLogic bl = new BusinessLogic();
            var conditions = bl.GetSkyConditions();

            Assert.AreEqual(conditions.Count, 5);
        }

        [Test]
        public void SkyConditionOptionsCorrect()
        {
            List<string> control = new List<string>
            {
                "Clear", "Cloudy", "PartlyCloudy", "Rain", "Snow"
            };

            BusinessLogic bl = new BusinessLogic();
            var conditions = bl.GetSkyConditions();

            Assert.AreEqual(conditions, control);
        }
    }
}