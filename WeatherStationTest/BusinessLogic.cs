using NUnit.Framework;
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

            bl.HighTemperature = 50;
            bl.WindSpeed = 20;

            var result = bl.CalculateWindChill();

            Assert.AreEqual(result, 43.599788069758056);
        }

        [Test]
        //[ExpectedMessage="You can't do that!"]
        public void TempTooHighFails()
        {
            BusinessLogic bl = new BusinessLogic();

            bl.HighTemperature = 50;
            bl.WindSpeed = 20;
        }
    }
}