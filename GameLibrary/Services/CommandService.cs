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
                case "turn left":
                    if (_car.Fuel >= 1)
                    {
                        _car.Fuel -= 1;
                        TurnLeft();
                        output = "The car driver turns left.";
                        _driver.IncreaseFatigue();
                        hungerService.IncreaseHunger();
                    }
                    else
                    {
                        output = "The car does not have enough gas to drive forward.";
                    }
                    break;

                case "2":
                case "turn right":
                    if (_car.Fuel >= 1)
                    {
                        _car.Fuel -= 1;
                        TurnRight();
                        output = "The car driver turns right.";
                        _driver.IncreaseFatigue();
                        hungerService.IncreaseHunger();
                    }
                    else
                    {
                        output = "The car does not have enough gas to drive forward.";
                    }
                    break;

                case "3":
                case "drive forward":
                    if (_car.Fuel >= 1)
                    {
                        _car.Fuel -= 1;

                        output = "The car driver drives forward.";
                        _driver.IncreaseFatigue();
                        hungerService.IncreaseHunger();
                    }
                    else
                    {
                        output = "The car does not have enough gas to drive forward.";
                    }
                    break;

                case "4":
                case "Reverse":
                    if (_car.Fuel >= 1)
                    {
                        _car.Fuel -= 1;

                        output = "The driver reverses.";
                        _driver.IncreaseFatigue();
                        hungerService.IncreaseHunger();
                    }
                    else
                    {
                        output = "The car does not have enough gas to drive forward.";
                    }
                    break;

                case "5":
                case "rest":
                    _driver.Fatigue = 1;
                    output = "The car driver takes a break and rests.";
                    hungerService.ResetHunger();
                    break;

                case "6":
                case "refuel the car":
                    _car.Fuel = 20;
                    output = "The car has been refueled.";
                    break;

                case "7":
                case "end":
                    output = "The game ends.";
                    break;

                default:
                    output = "Invalid command. Try again.";
                    break;
            }

            output += $"\nThe direction of the car: {_car.Direction}";
            output += $"\nGas: {_car.Fuel}/20";
            output += $"\nDriver fatigue: {_driver.Fatigue}/10";
            output += $"\nDriver's hunger: {_driver.Hunger}";

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

