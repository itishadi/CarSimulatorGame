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

        private Driver driver;
        private Car car;
        private CommandService commandService;
        private ApiService apiService;
        private bool isRunning;

        public FuelService(Driver driver, Car car, CommandService commandService, ApiService apiService)
        {
            this.driver = driver;
            this.car = car;
            this.commandService = commandService;
            this.apiService = apiService;
        }

        public void Fuel(string input)
        {
            if (car.Fuel <= 0)
            {
                Console.Clear();
                Console.WriteLine("*--------------------------------------------------------------*");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThe car does not have enough gas.\n");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("*--------------------------------------------------------------*");
                Console.WriteLine("\n1: Refuel");
                Console.WriteLine("2: Or press whatever you want and then ENTER to exit!\n");
                Console.WriteLine("*--------------------------------------------------------------*");
                Console.Write("Ange ett kommando: ");
                string fuelCommand = Console.ReadLine();
                Console.Clear();

                if (fuelCommand == "1")
                {
                    commandService.ExecuteCommand("6");
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            else if (car.Fuel == 1)
            {
                Console.WriteLine("*--------------------------------------------------------------*");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThe fuel level is low. Refuel the car!");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
