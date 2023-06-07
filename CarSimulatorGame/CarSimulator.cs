using GameLibrary.Models;
using GameLibrary.Services;
using System;

namespace CarSimulatorGame
{
    internal class CarSimulator
    {
        private Driver driver;
        private Car car;
        private CommandService commandService;

        public CarSimulator()
        {
            driver = new Driver();
            car = new Car();
            commandService = new CommandService(driver, car);
        }

        public void Start()
        {
            Console.WriteLine("Välkommen till Car Simulator!");

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
                    Console.WriteLine("*--------------------------------------------------------------*");
                    Console.WriteLine("Föraren är trött du måste ta en rast.");
                    Console.WriteLine("*--------------------------------------------------------------*");
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
                    Console.WriteLine("Föraren är hungrig Ta en rast!");
                }
                else if (driver.Fatigue == 9)
                {
                    Console.WriteLine("*--------------------------------------------------------------*");
                    Console.WriteLine("Föraren är trött och hungrig. Ta en rast!");
                }
                else if (input.ToLower() == "7" || input.ToLower() == "avsluta")
                {
                    isRunning = false;
                }


                if (car.Fuel <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("*--------------------------------------------------------------*");
                    Console.WriteLine("Bilen har inte tillräckligt med bensin.");
                    Console.WriteLine("*--------------------------------------------------------------*");
                    Console.WriteLine("1: Tanka");
                    Console.WriteLine("2: Eller tryck vad du vill och sedan ENTER för att avsluta!");
                    Console.WriteLine("*--------------------------------------------------------------*");
                    Console.Write("Ange ett kommando: ");
                    string fuelCommand = Console.ReadLine();

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
                    Console.WriteLine("Bensinnivån är låg. Tanka bilen!");
                }
                else if (input.ToLower() == "7" || input.ToLower() == "avsluta")
                {
                    isRunning = false;
                }
            }
        }

        public static void Main(string[] args)
        {
            CarSimulator simulator = new CarSimulator();
            simulator.Start();
        }
    }
}

