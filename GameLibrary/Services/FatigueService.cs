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
        private Driver _driver;

        public FatigueService(Driver driver, Car car, CommandService commandService, ApiService apiService)
        {
            _driver = driver;
        }

        public void Fatigue(string input)
        {
            if (_driver.Fatigue > 10)
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
