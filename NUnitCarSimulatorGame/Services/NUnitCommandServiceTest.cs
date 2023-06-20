using GameLibrary.Models;
using GameLibrary.Services;
using NUnit.Framework;

namespace NUnitCarSimulatorGame.Services
{
    [TestFixture]
    public class NUnitCommandServiceTest
    {
        private CommandService _commandService;
        private Car _car;

        [SetUp]
        public void Setup()
        {
            _car = new Car();
            _commandService = new CommandService(new Driver(), _car);
        }

        [Test]
        public void ExecuteCommand_ShouldChangeDirectionToWest_WhenInputIs1AndCurrentDirectionIsNorthward()
        {
            // Arrange
            _car.Direction = "Northward";

            // Act
            _commandService.ExecuteCommand("1");

            // Assert
            Assert.AreEqual("West", _car.Direction);
        }

        [Test]
        public void ExecuteCommand_ShouldChangeDirectionToEast_WhenInputIs1AndCurrentDirectionIsSouthward()
        {
            // Arrange
            _car.Direction = "Southward";

            // Act
            _commandService.ExecuteCommand("1");

            // Assert
            Assert.AreEqual("East", _car.Direction);
        }
    }
}
