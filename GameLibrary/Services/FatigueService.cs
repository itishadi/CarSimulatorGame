//using GameLibrary.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GameLibrary.Services
//{
//    public class FatigueService : IFatigueService
//    {
//        private Driver driver;
//        private Car car;
//        private CommandService commandService;
//        private ApiService apiService;
//        private bool isRunning;

//        public FatigueService(Driver driver, Car car, CommandService commandService, ApiService apiService)
//        {
//            this.driver = driver;
//            this.car = car;
//            this.commandService = commandService;
//            this.apiService = apiService;
//        }


//        public void Fatigue(string input)
//        {
//            if (driver.Fatigue >= 10)
//            {
//                Console.Clear();
//                Console.BackgroundColor = ConsoleColor.Black;
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("*--------------------------------------------------------------*");
//                Console.WriteLine("\nThe driver is tired and hungry, you must take a break.\n");
//                Console.WriteLine("*--------------------------------------------------------------*");
//                Console.BackgroundColor = ConsoleColor.Black;
//                Console.ForegroundColor = ConsoleColor.White;
//                Console.Clear();
//                Console.WriteLine("\n1: Take a break");
//                Console.WriteLine("2: Or press whatever you want and then ENTER to exit!");
//                Console.WriteLine("*--------------------------------------------------------------*");

//                Console.Write("\nEnter a command: ");
//                string fatigueCommand = Console.ReadLine();
//                Console.Clear();


//                if (fatigueCommand == "1")
//                {
//                    commandService.ExecuteCommand("5");
//                }
//                else
//                {
//                    isRunning = false;
//                }
//            }
//            else if (driver.Fatigue == 7 || driver.Fatigue == 8)
//            {
//                Console.WriteLine("*--------------------------------------------------------------*");
//                Console.BackgroundColor = ConsoleColor.Black;
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("\nThe driver is hungry Take a break!");
//                Console.BackgroundColor = ConsoleColor.Black;
//                Console.ForegroundColor = ConsoleColor.White;
//            }
//            else if (driver.Fatigue == 9)
//            {
//                Console.WriteLine("*--------------------------------------------------------------*");
//                Console.BackgroundColor = ConsoleColor.Black;
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("\nThe driver is tired and hungry. Take a break!");
//                Console.BackgroundColor = ConsoleColor.Black;
//                Console.ForegroundColor = ConsoleColor.White;
//            }
//            else if (input.ToLower() == "7" || input.ToLower() == "End")
//            {
//                isRunning = false;
//            }
//        }
//    }
//}
