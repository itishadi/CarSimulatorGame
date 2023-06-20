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

        ///////////////Turn left
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
