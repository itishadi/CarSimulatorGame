using GameLibrary.Models;
using GameLibrary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace CarSimulatorGameTest.Services
{
    [TestClass]
    public class CommandServiceTests
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

        /////////////////////////switch test
        [TestMethod]
        public void ExecuteCommand_InputIs1_CarTurnsLeftAndDriverFatigueIncreases()
        {
            // Arrange
            string input = "1";
            int initialFuel = 10;
            int initialFatigue = 0;
            _car.Fuel = initialFuel;
            _driver.Fatigue = initialFatigue;

            // Act
            string result = _sut.ExecuteCommand(input);

            // Assert
            Assert.AreEqual("West", _car.Direction);
            Assert.AreEqual(initialFuel - 1, _car.Fuel);
            Assert.AreEqual(initialFatigue + 1, _driver.Fatigue);
            Assert.IsTrue(result.Contains("West"));
            Assert.IsTrue(result.Contains($"{_car.Fuel}/20"));
            Assert.IsTrue(result.Contains($"{_driver.Fatigue}/10"));
        }
        [TestMethod]
        public void ExecuteCommand_InputIs2_CarTurnsRightAndDriverFatigueIncreases()
        {
            // Arrange
            string input = "2";
            int initialFuel = 10;
            int initialFatigue = 0;
            _car.Fuel = initialFuel;
            _driver.Fatigue = initialFatigue;

            // Act
            string result = _sut.ExecuteCommand(input);

            // Assert
            Assert.AreEqual("East", _car.Direction);
            Assert.AreEqual(initialFuel - 1, _car.Fuel);
            Assert.AreEqual(initialFatigue + 1, _driver.Fatigue);
            Assert.IsTrue(result.Contains("East"));
            Assert.IsTrue(result.Contains($"{_car.Fuel}/20"));
            Assert.IsTrue(result.Contains($"{_driver.Fatigue}/10"));
        }

        [TestMethod]
        public void ExecuteCommand_InputIs3_CarMovesForwardAndDriverFatigueIncreases()
        {
            // Arrange
            string input = "3";
            int initialFuel = 10;
            int initialFatigue = 0;
            _car.Fuel = initialFuel;
            _driver.Fatigue = initialFatigue;

            // Act
            string result = _sut.ExecuteCommand(input);

            // Assert
            Assert.AreEqual(initialFuel - 1, _car.Fuel);
            Assert.AreEqual(initialFatigue + 1, _driver.Fatigue);
            Assert.IsTrue(result.Contains($"{_car.Fuel}/20"));
            Assert.IsTrue(result.Contains($"{_driver.Fatigue}/10"));
        }

        [TestMethod]
        public void ExecuteCommand_InputIs4_CarMovesBackwardAndDriverFatigueIncreases()
        {
            // Arrange
            string input = "4";
            int initialFuel = 10;
            int initialFatigue = 0;
            _car.Fuel = initialFuel;
            _driver.Fatigue = initialFatigue;

            // Act
            string result = _sut.ExecuteCommand(input);

            // Assert
            Assert.AreEqual(initialFuel - 1, _car.Fuel);
            Assert.AreEqual(initialFatigue + 1, _driver.Fatigue);
            Assert.IsTrue(result.Contains($"{_car.Fuel}/20"));
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
            Assert.IsTrue(result.Contains($"{_car.Direction}"));
            Assert.IsTrue(result.Contains($"{_car.Fuel}/20"));
            Assert.IsTrue(result.Contains($"{_driver.Fatigue}/10"));
        }



        ///////////////Turn left test
        [TestMethod]
        public void TurnLeft_CarDirectionIsNorthward_CarDirectionChangesToWest()
        {
            // Arrange
            _car.Direction = "Northward";
            CommandService sut = new CommandService(_driver, _car);

            // Act
            MethodInfo turnLeftMethod = typeof(CommandService).GetMethod("TurnLeft", BindingFlags.NonPublic | BindingFlags.Instance);
            turnLeftMethod.Invoke(sut, null);

            // Assert
            Assert.AreEqual("West", _car.Direction);
        }

        [TestMethod]
        public void TurnLeft_CarDirectionIsSouthward_CarDirectionChangesToEast()
        {
            // Arrange
            _car.Direction = "Southward";
            CommandService sut = new CommandService(_driver, _car);

            // Act
            MethodInfo turnLeftMethod = typeof(CommandService).GetMethod("TurnLeft", BindingFlags.NonPublic | BindingFlags.Instance);
            turnLeftMethod.Invoke(sut, null);

            // Assert
            Assert.AreEqual("East", _car.Direction);
        }

        [TestMethod]
        public void TurnLeft_CarDirectionIsWest_CarDirectionChangesToSouthward()
        {
            // Arrange
            _car.Direction = "West";
            CommandService sut = new CommandService(_driver, _car);

            // Act
            MethodInfo turnLeftMethod = typeof(CommandService).GetMethod("TurnLeft", BindingFlags.NonPublic | BindingFlags.Instance);
            turnLeftMethod.Invoke(sut, null);

            // Assert
            Assert.AreEqual("Southward", _car.Direction);
        }

        [TestMethod]
        public void TurnLeft_CarDirectionIsEast_CarDirectionChangesToNorthward()
        {
            // Arrange
            _car.Direction = "East";
            CommandService sut = new CommandService(_driver, _car);

            // Act
            MethodInfo turnLeftMethod = typeof(CommandService).GetMethod("TurnLeft", BindingFlags.NonPublic | BindingFlags.Instance);
            turnLeftMethod.Invoke(sut, null);

            // Assert
            Assert.AreEqual("Northward", _car.Direction);
        }


        ///////////////Turn right test
        [TestMethod]
        public void TurnRight_CarDirectionIsNorthward_CarDirectionChangesToEast()
        {
            // Arrange
            _car.Direction = "Northward";
            CommandService sut = new CommandService(_driver, _car);

            // Act
            MethodInfo turnRightMethod = typeof(CommandService).GetMethod("TurnRight", BindingFlags.NonPublic | BindingFlags.Instance);
            turnRightMethod.Invoke(sut, null);

            // Assert
            Assert.AreEqual("East", _car.Direction);
        }
        [TestMethod]
        public void TurnRight_CarDirectionIsSouthward_CarDirectionChangesToWest()
        {
            // Arrange
            _car.Direction = "Southward";
            CommandService sut = new CommandService(_driver, _car);

            // Act
            MethodInfo turnRightMethod = typeof(CommandService).GetMethod("TurnRight", BindingFlags.NonPublic | BindingFlags.Instance);
            turnRightMethod.Invoke(sut, null);

            // Assert
            Assert.AreEqual("West", _car.Direction);
        }
        [TestMethod]
        public void TurnRight_CarDirectionIsWest_CarDirectionChangesToNorthward()
        {
            // Arrange
            _car.Direction = "West";
            CommandService sut = new CommandService(_driver, _car);

            // Act
            MethodInfo turnRightMethod = typeof(CommandService).GetMethod("TurnRight", BindingFlags.NonPublic | BindingFlags.Instance);
            turnRightMethod.Invoke(sut, null);

            // Assert
            Assert.AreEqual("Northward", _car.Direction);
        }
        [TestMethod]
        public void TurnRight_CarDirectionIsEast_CarDirectionChangesToSouthward()
        {
            // Arrange
            _car.Direction = "East";
            CommandService sut = new CommandService(_driver, _car);

            // Act
            MethodInfo turnRightMethod = typeof(CommandService).GetMethod("TurnRight", BindingFlags.NonPublic | BindingFlags.Instance);
            turnRightMethod.Invoke(sut, null);

            // Assert
            Assert.AreEqual("Southward", _car.Direction);
        }

    }
}
