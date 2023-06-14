using System;
using System.IO;
using System.Threading.Tasks;
using GameLibrary.Models;
using GameLibrary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CarSimulatorGameTest.Services
{
    [TestClass]
    public class MenuServiceTests
    {
        //[TestMethod]
        //public async Task Start_Should_Display_TurnLeftOption()
        //{
        //    // Arrange
        //    var driverMock = new Mock<Driver>();
        //    var carMock = new Mock<Car>();
        //    var commandServiceMock = new Mock<CommandService>();
        //    var apiServiceMock = new Mock<ApiService>();
        //    var fatigueServiceMock = new Mock<FatigueService>();
        //    var fuelServiceMock = new Mock<FuelService>();

        //    var output = new StringWriter();
        //    var menuService = new MenuService(driverMock.Object, carMock.Object, commandServiceMock.Object,
        //        apiServiceMock.Object, fatigueServiceMock.Object, fuelServiceMock.Object);

        //    var userInput = "1"; // Simulate user input: Start

        //    // Create a TextReader to simulate the user input
        //    using (var input = new StringReader(userInput))
        //    using (output)
        //    {
        //        Console.SetIn(input);
        //        Console.SetOut(output);

        //        // Act
        //        await menuService.Start();

        //        // Assert
        //        // Verify that "1: Turn left" option is displayed in the menu
        //        StringAssert.Contains(output.ToString(), "1: Turn left");
        //    }
        //}




    }
}
