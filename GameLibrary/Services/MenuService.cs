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
        private FatigueService fatigueService;

        public MenuService(Driver driver, Car car, CommandService commandService, ApiService apiService, FatigueService fatigueService)
        {
            this.driver = driver;
            this.car = car;
            this.commandService = commandService;
            this.apiService = apiService;
            this.fatigueService = fatigueService;

        }

        public async Task Start()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Car Simulator!");
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
                Console.WriteLine("7: End!");
                Console.WriteLine("\n*--------------------------------------------------------------*");
                Console.Write("Enter a command: ");

                string input = Console.ReadLine();
                string output = commandService.ExecuteCommand(input);

                Console.Clear();
                Console.WriteLine(output);
                fatigueService.Fatigue(input);
                Fuel(input);
            }
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
                    isRunning = false;
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
            else if (input.ToLower() == "7" || input.ToLower() == "End")
            {
                isRunning = false;
            }
        }
    }
}
