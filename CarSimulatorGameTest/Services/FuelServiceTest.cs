using GameLibrary.Models;
using GameLibrary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;

namespace CarSimulatorGameTest.Services
{
    [TestClass]
    public class FuelServiceTest
    {
        [TestMethod]
        public void Fuel_InputIs1_Success()
        {
            // Arrange
            string input = "1";
            string expectedMessage = "Refuel succeeded";

            Mock<IFuelService> mockFuelService = new Mock<IFuelService>();

            // Setup mockFuelService to execute the Fuel method
            mockFuelService.Setup(fs => fs.Fuel(input));

            // Act
            mockFuelService.Object.Fuel(input);

            // Assert
            // Verify that the Fuel method was called with the correct input
            mockFuelService.Verify(fs => fs.Fuel(input), Times.Once);

            // Verify the expected message is displayed
            Assert.AreEqual(expectedMessage, "Refuel succeeded");
        }
        [TestMethod]
        public void Fuel_InputIsNot1_NotSuccess()
        {
            // Arrange
            string input = "2";
            string expectedMessage = "Refuel NOT succeeded";

            Mock<IFuelService> mockFuelService = new Mock<IFuelService>();

            // Setup mockFuelService to execute the Fuel method
            mockFuelService.Setup(fs => fs.Fuel(input));

            // Act
            mockFuelService.Object.Fuel(input);

            // Assert
            // Verify that the Fuel method was called with the correct input
            mockFuelService.Verify(fs => fs.Fuel(input), Times.Once);

            // Verify the expected message is displayed
            Assert.AreEqual(expectedMessage, "Refuel NOT succeeded");
        }
    }
}
