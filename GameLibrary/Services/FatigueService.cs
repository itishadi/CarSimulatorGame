using GameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Services
{
    public class FatigueService : IFatigueService
    {
        private Driver driver;
        private Car car;
        private CommandService commandService;
        private ApiService apiService;
        private bool isRunning;

        public FatigueService(Driver driver, Car car, CommandService commandService, ApiService apiService)
        {
            this.driver = driver;
            this.car = car;
            this.commandService = commandService;
            this.apiService = apiService;
        }


        public void Fatigue(string input)
        {
            if (driver.Fatigue > 10)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("*--------------------------------------------------------------*");
                Console.WriteLine("\nThe driver is tired take a break.\n");
                Console.WriteLine("*--------------------------------------------------------------*");
                Console.ResetColor();
            }
        }
    }
}
