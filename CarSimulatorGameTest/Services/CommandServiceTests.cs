using GameLibrary.Models;
using GameLibrary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace CarSimulatorGameTest.Services
{
    [TestClass]
    public class CommandServiceTests
    {
        private CommandService sut;
        private Car car;
        private Driver driver;

        [TestInitialize]
        public void Setup()
        {
            car = new Car();
            driver = new Driver();
            sut = new CommandService(driver, car);
        }

        [TestMethod]
        public void ExecuteCommand_ShouldReturnCorrectOutput_WhenInputIs1()
        {
            // Arrange
            string input = "1";
            string expectedOutput = "The driver turns left." +
                "\nCar direction: West\nFuel: 19/20" +
                "\nDriver fatigue: 1/10" +
                "\nDriver hunger: NotHungry";

            // Act
            string actualOutput = sut.ExecuteCommand(input);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        //[TestMethod]
        //public void TurnLeft_ShouldChangeCarDirectionToWest_WhenCurrentDirectionIsNorth()
        //{
        //    // Arrange
        //    car.Direction = "North";
        //    string expectedDirection = "West";

        //    // Act
        //    InvokePrivateMethod(sut, "TurnLeft");

        //    // Assert
        //    Assert.AreEqual(expectedDirection, car.Direction);
        //}

        //private static void InvokePrivateMethod(object obj, string methodName)
        //{
        //    var method = obj.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
        //    method.Invoke(obj, null);
        //}

        //[TestMethod]
        //public void TurnRight_ShouldChangeCarDirectionToEast_WhenCurrentDirectionIsNorth()
        //{
        //    // Arrange
        //    car.Direction = "North";
        //    string expectedDirection = "East";

        //    // Act
        //    InvokePrivateMethod(sut, "TurnRight");

        //    // Assert
        //    Assert.AreEqual(expectedDirection, car.Direction);
        //}
    }
}
