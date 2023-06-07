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
        private Driver driver;
        private Car car;
        private CommandService commandService;
        private ApiService apiService;

        public MenuService(Driver driver, Car car, CommandService commandService, ApiService apiService)
        {
            this.driver = driver;
            this.car = car;
            this.commandService = commandService;
            this.apiService = apiService;
        }

        public async Task Start()
        {

            Console.WriteLine("Välkommen till Car Simulator!");
            await apiService.GetAsync();
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("*--------------------------------------------------------------*");
                Console.WriteLine("1: Sväng Vänster");
                Console.WriteLine("2: Sväng Höger");
                Console.WriteLine("3: Kör framåt");
                Console.WriteLine("4: Backa");
                Console.WriteLine("5: Ta rast");
                Console.WriteLine("6: Tanka");
                Console.WriteLine("7: Avsluta!");

                Console.WriteLine("*--------------------------------------------------------------*");
                Console.Write("Ange ett kommando: ");
                string input = Console.ReadLine();
                string output = commandService.ExecuteCommand(input);

                Console.Clear();

                Console.WriteLine(output);

                if (driver.Fatigue >= 10)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*--------------------------------------------------------------*");
                    Console.WriteLine("Föraren är trött hungig du måste ta en rast.");
                    Console.WriteLine("*--------------------------------------------------------------*");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.WriteLine("1: Ta rast");
                    Console.WriteLine("2: Eller tryck vad du vill och sedan ENTER för att avsluta!");
                    Console.WriteLine("*--------------------------------------------------------------*");
                    Console.Write("Ange ett kommando: ");
                    string fatigueCommand = Console.ReadLine();

                    if (fatigueCommand == "1")
                    {
                        commandService.ExecuteCommand("5");
                    }
                    else
                    {
                        isRunning = false;
                    }
                }
                else if (driver.Fatigue == 7 || driver.Fatigue == 8)
                {
                    Console.WriteLine("*--------------------------------------------------------------*");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Föraren är hungrig Ta en rast!");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (driver.Fatigue == 9)
                {
                    Console.WriteLine("*--------------------------------------------------------------*");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Föraren är trött och hungrig. Ta en rast!");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.ToLower() == "7" || input.ToLower() == "avsluta")
                {
                    isRunning = false;
                }


                if (car.Fuel <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("*--------------------------------------------------------------*");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bilen har inte tillräckligt bensin.");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("*--------------------------------------------------------------*");
                    Console.WriteLine("1: Tanka");
                    Console.WriteLine("2: Eller tryck vad du vill och sedan ENTER för att avsluta!");
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
                    Console.WriteLine("Bensinnivån är låg. Tanka bilen!");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.ToLower() == "7" || input.ToLower() == "avsluta")
                {
                    isRunning = false;
                }

            }
        }
    }
}
