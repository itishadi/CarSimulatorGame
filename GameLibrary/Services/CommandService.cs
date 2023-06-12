using GameLibrary.Models;

namespace GameLibrary.Services
{
    public class CommandService : ICommandService
    {
        private Driver _driver;
        private Car _car;
        private HungerService hungerService;

      
        public CommandService(Driver driver, Car car)
        {
            _driver = driver;
            _car = car;
            hungerService = new HungerService(driver);
        }

        public string ExecuteCommand(string input)
        {
            string output = "";

            switch (input.ToLower())
            {
                case "1":
                    if (_car.Fuel >= 1)
                    {
                        _car.Fuel -= 1;
                        TurnLeft();
                        _driver.IncreaseFatigue();
                        //hungerService.IncreaseHunger();
                    }
                    break;

                case "2":
                    if (_car.Fuel >= 1)
                    {
                        _car.Fuel -= 1;
                        TurnRight();
                        _driver.IncreaseFatigue();
                        //hungerService.IncreaseHunger();
                    }
                    break;

                case "3":
                    if (_car.Fuel >= 1)
                    {
                        _car.Fuel -= 1;

                        _driver.IncreaseFatigue();
                        //hungerService.IncreaseHunger();
                    }
                    break;

                case "4":
                    if (_car.Fuel >= 1)
                    {
                        _car.Fuel -= 1;

                        _driver.IncreaseFatigue();
                        //hungerService.IncreaseHunger();
                    }
                    break;

                case "5":
                    _driver.Fatigue = 1;
                    //hungerService.ResetHunger();
                    break;

                case "6":
                    _car.Fuel = 20;
                    Console.WriteLine(
                        output += $"\nThe direction of the car: {_car.Direction}" +
                        $"\nGas: {_car.Fuel}/20 " +
                        $"\nDriver fatigue: {_driver.Fatigue}/10 " 
                        //$"\nDriver's hunger: {_driver.Hunger}"
                        );
                    break;

                case "7":
                    break;

                default:
                    output = "Invalid command. Try again.";
                    break;
            }

            output += $"\nThe direction of the car: {_car.Direction}";
            output += $"\nGas: {_car.Fuel}/20";
            output += $"\nDriver fatigue: {_driver.Fatigue}/10";
            //output += $"\nDriver's hunger: {_driver.Hunger}";

            return output;
        }

        private void TurnLeft()
        {
            switch (_car.Direction)
            {
                case "Northward":
                    _car.Direction = "West";
                    break;

                case "Southward":
                    _car.Direction = "East";
                    break;

                case "West":
                    _car.Direction = "Southward";
                    break;

                case "East":
                    _car.Direction = "Northward";
                    break;
            }
        }

        private void TurnRight()
        {
            switch (_car.Direction)
            {
                case "Northward":
                    _car.Direction = "East";
                    break;

                case "Southward":
                    _car.Direction = "West";
                    break;

                case "West":
                    _car.Direction = "Northward";
                    break;

                case "East":
                    _car.Direction = "Southward";
                    break;
            }
        }
    }
}

