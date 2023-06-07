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
            string input = "1";
            string expectedOutput = "Bilföraren svänger vänster." +
                "\nBilens riktning: Västerut\nBensin: 19/20" +
                "\nFörarens trötthet: 1/10" +
                "\nFörarens hunger: NotHungry";

            string actualOutput = sut.ExecuteCommand(input);

            Assert.AreEqual(expectedOutput, actualOutput);
        }
        [TestMethod]
        public void TurnLeft_ShouldChangeCarDirectionToWest_WhenCurrentDirectionIsNorth()
        {
            car.Direction = "Norrut";
            string expectedDirection = "Västerut";

            InvokePrivateMethod(sut, "TurnLeft");

            Assert.AreEqual(expectedDirection, car.Direction);
        }

        private static void InvokePrivateMethod(object obj, string methodName)
        {
            var method = obj.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
            method.Invoke(obj, null);
        }


        [TestMethod]
        public void TurnRight_ShouldChangeCarDirectionToEast_WhenCurrentDirectionIsNorth()
        {
            car.Direction = "Norrut";
            string expectedDirection = "Österut";

            InvokePrivateMethod1(sut, "TurnRight");

            Assert.AreEqual(expectedDirection, car.Direction);
        }

        private static void InvokePrivateMethod1(object obj, string methodName)
        {
            var method = obj.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
            method.Invoke(obj, null);
        }

    }
}
