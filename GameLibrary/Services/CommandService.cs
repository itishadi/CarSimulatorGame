//using GameLibrary.Models;

//namespace GameLibrary.Services
//{
//    public class CommandService : ICommandService
//    {
//        private Driver _driver;
//        private Car _car;
//        private HungerService hungerService;


//        public CommandService(Driver driver, Car car)
//        {
//            _driver = driver;
//            _car = car;
//            hungerService = new HungerService(driver);
//        }

//        public string ExecuteCommand(string input)
//        {
//            string output = "";

//            switch (input.ToLower())
//            {
//                case "1":
//                case "sväng vänster":
//                    if (_car.Fuel >= 1)
//                    {
//                        _car.Fuel -= 1;
//                        TurnLeft();
//                        output = "Bilföraren svänger vänster.";
//                        _driver.IncreaseFatigue();
//                        hungerService.IncreaseHunger();
//                    }
//                    else
//                    {
//                        output = "Bilen har inte tillräckligt med bensin för att köra framåt.";
//                    }
//                    break;

//                case "2":
//                case "sväng höger":
//                    if (_car.Fuel >= 1)
//                    {
//                        _car.Fuel -= 1;
//                        TurnRight();
//                        output = "Bilföraren svänger höger.";
//                        _driver.IncreaseFatigue();
//                        hungerService.IncreaseHunger();
//                    }
//                    else
//                    {
//                        output = "Bilen har inte tillräckligt med bensin för att köra framåt.";
//                    }
//                    break;

//                case "3":
//                case "köra framåt":
//                    if (_car.Fuel >= 1)
//                    {
//                        _car.Fuel -= 1;

//                        output = "Bilföraren kör framåt.";
//                        _driver.IncreaseFatigue();
//                        hungerService.IncreaseHunger();
//                    }
//                    else
//                    {
//                        output = "Bilen har inte tillräckligt med bensin för att köra framåt.";
//                    }
//                    break;

//                case "4":
//                case "backa":
//                    if (_car.Fuel >= 1)
//                    {
//                        _car.Fuel -= 1;

//                        output = "Bilföraren backar.";
//                        _driver.IncreaseFatigue();
//                        hungerService.IncreaseHunger();
//                    }
//                    else
//                    {
//                        output = "Bilen har inte tillräckligt med bensin för att köra framåt.";
//                    }
//                    break;

//                case "5":
//                case "rasta":
//                    _driver.Fatigue = 1;
//                    output = "Bilföraren tar en paus och vilar.";
//                    hungerService.ResetHunger();
//                    break;

//                case "6":
//                case "tanka bilen":
//                    _car.Fuel = 20;
//                    output = "Bilen har tankats.";
//                    break;

//                case "7":
//                case "avsluta":
//                    output = "Spelet avslutas.";
//                    break;

//                default:
//                    output = "Ogiltigt kommando. Försök igen.";
//                    break;
//            }

//            output += $"\nBilens riktning: {_car.Direction}";
//            output += $"\nBensin: {_car.Fuel}/20";
//            output += $"\nFörarens trötthet: {_driver.Fatigue}/10";
//            output += $"\nFörarens hunger: {_driver.Hunger}";

//            return output;
//        }

//        private void TurnLeft()
//        {
//            switch (_car.Direction)
//            {
//                case "Norrut":
//                    _car.Direction = "Västerut";
//                    break;

//                case "Söderut":
//                    _car.Direction = "Österut";
//                    break;

//                case "Västerut":
//                    _car.Direction = "Söderut";
//                    break;

//                case "Österut":
//                    _car.Direction = "Norrut";
//                    break;
//            }
//        }

//        private void TurnRight()
//        {
//            switch (_car.Direction)
//            {
//                case "Norrut":
//                    _car.Direction = "Österut";
//                    break;

//                case "Söderut":
//                    _car.Direction = "Västerut";
//                    break;

//                case "Västerut":
//                    _car.Direction = "Norrut";
//                    break;

//                case "Österut":
//                    _car.Direction = "Söderut";
//                    break;
//            }
//        }
//    }
//}

using GameLibrary.Models;

namespace GameLibrary.Services
{
    public class CommandService : ICommandService
    {
        private readonly Driver _driver;
        private readonly Car _car;
        private readonly HungerService _hungerService;

        public CommandService(Driver driver, Car car)
        {
            _driver = driver;
            _car = car;
            _hungerService = new HungerService(driver);
        }

        public string ExecuteCommand(string input)
        {
            string output = "";

            switch (input.ToLower())
            {
                case "1":
                case "sväng vänster":
                    if (_car.Fuel >= 1)
                    {
                        _car.Fuel -= 1;
                        TurnLeft();
                        output = "The driver turns left.";
                        _driver.IncreaseFatigue();
                        _hungerService.IncreaseHunger();
                    }
                    else
                    {
                        output = "The car doesn't have enough fuel to move forward.";
                    }
                    break;

                case "2":
                case "sväng höger":
                    if (_car.Fuel >= 1)
                    {
                        _car.Fuel -= 1;
                        TurnRight();
                        output = "The driver turns right.";
                        _driver.IncreaseFatigue();
                        _hungerService.IncreaseHunger();
                    }
                    else
                    {
                        output = "The car doesn't have enough fuel to move forward.";
                    }
                    break;

                case "3":
                case "köra framåt":
                    if (_car.Fuel >= 1)
                    {
                        _car.Fuel -= 1;
                        output = "The driver moves forward.";
                        _driver.IncreaseFatigue();
                        _hungerService.IncreaseHunger();
                    }
                    else
                    {
                        output = "The car doesn't have enough fuel to move forward.";
                    }
                    break;

                case "4":
                case "backa":
                    if (_car.Fuel >= 1)
                    {
                        _car.Fuel -= 1;
                        output = "The driver moves backward.";
                        _driver.IncreaseFatigue();
                        _hungerService.IncreaseHunger();
                    }
                    else
                    {
                        output = "The car doesn't have enough fuel to move forward.";
                    }
                    break;

                case "5":
                case "rasta":
                    _driver.Fatigue = 1;
                    output = "The driver takes a break and rests.";
                    _hungerService.ResetHunger();
                    break;

                case "6":
                case "tanka bilen":
                    _car.Fuel = 20;
                    output = "The car has been refueled.";
                    break;

                case "7":
                case "avsluta":
                    output = "The game ends.";
                    break;

                default:
                    output = "Invalid command. Please try again.";
                    break;
            }

            output += $"\nCar direction: {_car.Direction}";
            output += $"\nFuel: {_car.Fuel}/20";
            output += $"\nDriver fatigue: {_driver.Fatigue}/10";
            output += $"\nDriver hunger: {_driver.Hunger}";

            return output;
        }

        private void TurnLeft()
        {
            switch (_car.Direction)
            {
                case "North":
                    _car.Direction = "West";
                    break;

                case "South":
                    _car.Direction = "East";
                    break;

                case "West":
                    _car.Direction = "South";
                    break;

                case "East":
                    _car.Direction = "North";
                    break;
            }
        }

        private void TurnRight()
        {
            switch (_car.Direction)
            {
                case "North":
                    _car.Direction = "East";
                    break;

                case "South":
                    _car.Direction = "West";
                    break;

                case "West":
                    _car.Direction = "North";
                    break;

                case "East":
                    _car.Direction = "South";
                    break;
            }
        }
    }
}

