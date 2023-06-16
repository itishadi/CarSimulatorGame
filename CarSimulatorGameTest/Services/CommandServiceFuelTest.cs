using GameLibrary.Models;
using GameLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulatorGameTest.Services
{
    [TestClass]
    public class CommandServiceFuelTest
    {
        private CommandService _sut;
        private Car _car;
        private Driver _driver;

        [TestInitialize]
        public void Setup()
        {
            _car = new Car();
            _driver = new Driver();
            _sut = new CommandService(_driver, _car);
        }


        [TestMethod]
        public void ExecuteCommand_InputIs1_CarTurnsLeftAndDriverFuelDecreases()
        {
            // Arrange
            string input = "1";
            int initialFuel = 10;
            _car.Fuel = initialFuel;

            // Act
            string result = _sut.ExecuteCommand(input);

            // Assert
            Assert.AreEqual("West", _car.Direction);
            Assert.AreEqual(initialFuel - 1, _car.Fuel);
            Assert.IsTrue(result.Contains("West"));
            Assert.IsTrue(result.Contains($"{_car.Fuel}/20"));
        }
        [TestMethod]
        public void ExecuteCommand_InputIs2_CarTurnsRightAndDriverFuelDecreases()
        {
            // Arrange
            string input = "2";
            int initialFuel = 10;
            _car.Fuel = initialFuel;

            // Act
            string result = _sut.ExecuteCommand(input);

            // Assert
            Assert.AreEqual("East", _car.Direction);
            Assert.AreEqual(initialFuel - 1, _car.Fuel);
            Assert.IsTrue(result.Contains("East"));
            Assert.IsTrue(result.Contains($"{_car.Fuel}/20"));
        }

        [TestMethod]
        public void ExecuteCommand_InputIs3_CarMovesForwardAndDriverFuelDecreases()
        {
            // Arrange
            string input = "3";
            int initialFuel = 10;
            _car.Fuel = initialFuel;

            // Act
            string result = _sut.ExecuteCommand(input);

            // Assert
            Assert.AreEqual(initialFuel - 1, _car.Fuel);
            Assert.IsTrue(result.Contains($"{_car.Fuel}/20"));
        }

        [TestMethod]
        public void ExecuteCommand_InputIs4_CarMovesBackwardAndDriverFuelDecreases()
        {
            // Arrange
            string input = "4";
            int initialFuel = 10;
            _car.Fuel = initialFuel;

            // Act
            string result = _sut.ExecuteCommand(input);

            // Assert
            Assert.AreEqual(initialFuel - 1, _car.Fuel);
            Assert.IsTrue(result.Contains($"{_car.Fuel}/20"));
        }

        [TestMethod]
        public void ExecuteCommand_InputIs6_CarFuelIsRefilledAndOutputContainsCarInformation()
        {
            // Arrange
            string input = "6";
            int initialFuel = 5;
            _car.Fuel = initialFuel;

            // Act
            string result = _sut.ExecuteCommand(input);

            // Assert
            Assert.AreEqual(20, _car.Fuel);
            Assert.IsTrue(result.Contains($"{_car.Fuel}/20"));
        }
    }
}
