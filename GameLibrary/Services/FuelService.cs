using GameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Services
{
    public class FuelService : IFuelService
    {

        private Car _car;
        private CommandService _commandService;

        public FuelService(Driver driver, Car car, CommandService commandService, ApiService apiService)
        {
            _car = car;
            _commandService = commandService;
        }

        public void Fuel(string input)
        {
            if (_car.Fuel <= 0)
            {
                Console.Clear();
                Console.WriteLine("*--------------------------------------------------------------*");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThe car does not have enough gas.\n");
                Console.ResetColor();
                Console.WriteLine("*--------------------------------------------------------------*");
                Console.WriteLine("\n1: Refuel");
                Console.WriteLine("2: Or press whatever you want and then ENTER to exit!\n");
                Console.WriteLine("*--------------------------------------------------------------*");
                Console.Write("Ange ett kommando: ");
                string fuelCommand = Console.ReadLine();
                Console.Clear();

                if (fuelCommand == "1")
                {
                    _commandService.ExecuteCommand("6");
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            else if (_car.Fuel == 1)
            {
                Console.WriteLine("*--------------------------------------------------------------*");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThe fuel level is low. Refuel the car!");
                Console.ResetColor();
            }
        }
    }
}
