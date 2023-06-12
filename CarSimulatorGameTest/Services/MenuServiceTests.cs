using System;
using System.IO;
using System.Threading.Tasks;
using GameLibrary.Models;
using GameLibrary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarSimulatorGameTest.Services
{
    [TestClass]
    public class MenuServiceTests
    {
        private MenuService _sut;
        private Driver _driver;
        private Car _car;
        private CommandService _commandService;
        private ApiService _apiService;
        private FatigueService _fatigueService;
        private FuelService _fuelService;

        [TestInitialize]
        public void Initialize()
        {
            _driver = new Driver();
            _car = new Car();
            _commandService = new CommandService(_driver, _car);
            _apiService = new ApiService();
            _fatigueService = new FatigueService(_driver, _car, _commandService, _apiService);
            _fuelService = new FuelService(_driver, _car, _commandService, _apiService);
            _sut = new MenuService(_driver, _car, _commandService, _apiService, _fatigueService, _fuelService);
        }

        //[TestMethod]
        //public async Task Start_InputIs1_ExecutesStartMenu()
        //{
        //    // Arrange
        //    string userInput = "1";
        //    string expectedOutput = "Welcome to Car Simulator!"; // Adjust the expected output based on the expected behavior

        //    using (StringReader sr = new StringReader(userInput))
        //    using (StringWriter sw = new StringWriter())
        //    {
        //        Console.SetIn(sr);
        //        Console.SetOut(sw);

        //        // Act
        //        await _sut.Start();

        //        // Assert
        //        string consoleOutput = sw.ToString();
        //        Assert.IsTrue(consoleOutput.Contains(expectedOutput));
        //        // You can add more assertions to verify the behavior and output of the MenuService
        //    }
        //}



    }
}
