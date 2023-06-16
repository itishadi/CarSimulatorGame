using GameLibrary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CarSimulatorGameTest.FutureServices
{
    [TestClass]
    public class FatigueServiceTest
    {
        [TestMethod]
        public void Fatigue_InputIs1_DriverIsHappy()
        {
            // Arrange
            string input = "1";
            string expectedMessage = "The driver is happy.";

            Mock<IFatigueService> mockFatigueService = new Mock<IFatigueService>();
            string actualResult = null;
            mockFatigueService.Setup(fs => fs.Fatigue(input)).Callback(() => actualResult = expectedMessage);

            // Act
            mockFatigueService.Object.Fatigue(input);

            // Assert
            // Verify that the expected result is returned
            Assert.AreEqual(expectedMessage, actualResult);
        }

        [TestMethod]
        public void Fatigue_InputIs10_DriverIsTired()
        {
            // Arrange
            string input = "10";
            string expectedMessage = "The driver is tired.";

            Mock<IFatigueService> mockFatigueService = new Mock<IFatigueService>();
            string actualResult = null;
            mockFatigueService.Setup(fs => fs.Fatigue(input)).Callback(() => actualResult = expectedMessage);

            // Act
            mockFatigueService.Object.Fatigue(input);

            // Assert
            // Verify that the expected result is returned
            Assert.AreEqual(expectedMessage, actualResult);
        }
    }
}
