using GameLibrary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CarSimulatorGameTest.ServicesMock
{
    [TestClass]
    public class HungerServiceTests
    {
        [TestMethod]
        public void IncreaseHunger_HungerLevel_1()
        {
            // Arrange
            int expectedHungerLevel = 1;
            string expectedDriver = "full";

            Mock<IHungerService> mockHungerService = new Mock<IHungerService>();
            mockHungerService.Setup(h => h.HungerLevel).Returns(expectedHungerLevel);

            // Act
            mockHungerService.Object.IncreaseHunger();

            // Assert
            Assert.AreEqual(expectedHungerLevel, mockHungerService.Object.HungerLevel);
            Assert.AreEqual(expectedDriver, "full");
        }
        [TestMethod]
        public void IncreaseHunger_HungerLevel_2()
        {
            // Arrange
            int expectedHungerLevel = 8;
            string expectedDriver = "Hungry";

            Mock<IHungerService> mockHungerService = new Mock<IHungerService>();
            mockHungerService.Setup(h => h.HungerLevel).Returns(expectedHungerLevel);

            // Act
            for (int i = 0; i < expectedHungerLevel; i++)
            {
                mockHungerService.Object.IncreaseHunger();
            }

            // Assert
            Assert.AreEqual(expectedHungerLevel, mockHungerService.Object.HungerLevel);
            Assert.AreEqual(expectedDriver, "Hungry");
        }

        [TestMethod]
        public void IncreaseHunger_HungerLevel_3()
        {
            // Arrange
            int expectedHungerLevel = 10;
            string expectedDriver = "Starving";

            Mock<IHungerService> mockHungerService = new Mock<IHungerService>();
            mockHungerService.Setup(h => h.HungerLevel).Returns(expectedHungerLevel);

            // Act
            for (int i = 0; i < expectedHungerLevel; i++)
            {
                mockHungerService.Object.IncreaseHunger();
            }

            // Assert
            Assert.AreEqual(expectedHungerLevel, mockHungerService.Object.HungerLevel);
            Assert.AreEqual(expectedDriver, "Starving");
        }
    }
}
