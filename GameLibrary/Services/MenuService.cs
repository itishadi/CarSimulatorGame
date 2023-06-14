using GameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Services
{
    public class MenuService : IMenuService
    {
        public bool isRunning { get; set; } = true;
        private Driver driver;
        private Car car;
        private CommandService commandService;
        private ApiService apiService;
        private FuelService fuelService;
        private FatigueService fatigueService;

        public MenuService(Driver driver, Car car, CommandService commandService, ApiService apiService, FatigueService fatigueService, FuelService fuelService)
        {
            this.driver = driver;
            this.car = car;
            this.commandService = commandService;
            this.apiService = apiService;
            this.fatigueService = fatigueService;
            this.fuelService = fuelService;
        }
        public async Task Start()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Car Simulator!");
            Console.WriteLine("1: Start");
            Console.WriteLine("2: End");
            var answer = Console.ReadLine();
            car.Fuel = 20;
            Console.Clear();
            if (answer == "1")
            {
                await apiService.GetAsync();

                while (isRunning)
                {
                    Console.WriteLine("\n*--------------------------------------------------------------*");
                    Console.WriteLine("\n1: Turn left");
                    Console.WriteLine("2: Turn right");
                    Console.WriteLine("3: Drive forward");
                    Console.WriteLine("4: Reverse");
                    Console.WriteLine("5: Take a break");
                    Console.WriteLine("6: Refuel");
                    Console.WriteLine("7: Menu!");
                    Console.WriteLine("\n*--------------------------------------------------------------*");
                    Console.Write("Enter a command: ");

                    string input = Console.ReadLine();
                    string output = commandService.ExecuteCommand(input);

                    Console.Clear();
                    Console.WriteLine(output);
                    fatigueService.Fatigue(input);
                    fuelService.Fuel(input);
                    if (input == "7")
                    {
                        await Start();
                    }
                    else if (input != "1" && input != "2" && input != "3" && input != "4" && input != "5" && input != "6")
                    {
                        Console.WriteLine("Try again!");
                    }
                }
            }
            else
            {
                isRunning = false;
            }
        }
    }
}
