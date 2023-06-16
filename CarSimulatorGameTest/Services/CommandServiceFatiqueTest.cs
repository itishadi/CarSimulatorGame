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
    public class CommandServiceFatiqueTest
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
        public void ExecuteCommand_InputIs1_CarTurnsLeftAndDriverFatigueIncreases()
        {
            // Arrange
            string input = "1";
            int initialFatigue = 0;
            _driver.Fatigue = initialFatigue;

            // Act
            string result = _sut.ExecuteCommand(input);

            // Assert
            Assert.AreEqual("West", _car.Direction);
            Assert.AreEqual(initialFatigue + 1, _driver.Fatigue);
            Assert.IsTrue(result.Contains("West"));
            Assert.IsTrue(result.Contains($"{_driver.Fatigue}/10"));
        }


        [TestMethod]
        public void ExecuteCommand_InputIs2_CarTurnsRightAndDriverFatigueIncreases()
        {
            // Arrange
            string input = "2";
            int initialFatigue = 0;
            _driver.Fatigue = initialFatigue;

            // Act
            string result = _sut.ExecuteCommand(input);

            // Assert
            Assert.AreEqual("East", _car.Direction);
            Assert.AreEqual(initialFatigue + 1, _driver.Fatigue);
            Assert.IsTrue(result.Contains("East"));
            Assert.IsTrue(result.Contains($"{_driver.Fatigue}/10"));
        }

        [TestMethod]
        public void ExecuteCommand_InputIs3_CarMovesForwardAndDriverFatigueIncreases()
        {
            // Arrange
            string input = "3";
            int initialFatigue = 0;
            _driver.Fatigue = initialFatigue;

            // Act
            string result = _sut.ExecuteCommand(input);

            // Assert
            Assert.AreEqual(initialFatigue + 1, _driver.Fatigue);
            Assert.IsTrue(result.Contains($"{_driver.Fatigue}/10"));
        }

        [TestMethod]
        public void ExecuteCommand_InputIs4_CarMovesBackwardAndDriverFatigueIncreases()
        {
            // Arrange
            string input = "4";
            int initialFatigue = 0;
            _driver.Fatigue = initialFatigue;

            // Act
            string result = _sut.ExecuteCommand(input);

            // Assert
            Assert.AreEqual(initialFatigue + 1, _driver.Fatigue);
            Assert.IsTrue(result.Contains($"{_driver.Fatigue}/10"));
        }

        [TestMethod]
        public void ExecuteCommand_InputIs5_DriverFatigueResets()
        {
            // Arrange
            string input = "5";
            int initialFatigue = 8;
            _driver.Fatigue = initialFatigue;

            // Act
            string result = _sut.ExecuteCommand(input);

            // Assert
            Assert.AreEqual(1, _driver.Fatigue);
            Assert.IsTrue(result.Contains($"{_driver.Fatigue}/10"));
        }

    }
}
