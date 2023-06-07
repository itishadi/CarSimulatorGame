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
                case "sväng vänster":
                    if (_car.Fuel >= 1)
                    {
                        _car.Fuel -= 1;
                        TurnLeft();
                        output = "Bilföraren svänger vänster.";
                        _driver.IncreaseFatigue();
                        hungerService.IncreaseHunger();
                    }
                    else
                    {
                        output = "Bilen har inte tillräckligt med bensin för att köra framåt.";
                    }
                    break;

                case "2":
                case "sväng höger":
                    if (_car.Fuel >= 1)
                    {
                        _car.Fuel -= 1;
                        TurnRight();
                        output = "Bilföraren svänger höger.";
                        _driver.IncreaseFatigue();
                        hungerService.IncreaseHunger();
                    }
                    else
                    {
                        output = "Bilen har inte tillräckligt med bensin för att köra framåt.";
                    }
                    break;

                case "3":
                case "köra framåt":
                    if (_car.Fuel >= 1)
                    {
                        _car.Fuel -= 1;

                        output = "Bilföraren kör framåt.";
                        _driver.IncreaseFatigue();
                        hungerService.IncreaseHunger();
                    }
                    else
                    {
                        output = "Bilen har inte tillräckligt med bensin för att köra framåt.";
                    }
                    break;

                case "4":
                case "backa":
                    if (_car.Fuel >= 1)
                    {
                        _car.Fuel -= 1;

                        output = "Bilföraren backar.";
                        _driver.IncreaseFatigue();
                        hungerService.IncreaseHunger();
                    }
                    else
                    {
                        output = "Bilen har inte tillräckligt med bensin för att köra framåt.";
                    }
                    break;

                case "5":
                case "rasta":
                    _driver.Fatigue = 1;
                    output = "Bilföraren tar en paus och vilar.";
                    hungerService.ResetHunger();
                    break;

                case "6":
                case "tanka bilen":
                    _car.Fuel = 20;
                    output = "Bilen har tankats.";
                    break;

                case "7":
                case "avsluta":
                    output = "Spelet avslutas.";
                    break;

                default:
                    output = "Ogiltigt kommando. Försök igen.";
                    break;
            }

            output += $"\nBilens riktning: {_car.Direction}";
            output += $"\nBensin: {_car.Fuel}/20";
            output += $"\nFörarens trötthet: {_driver.Fatigue}/10";
            output += $"\nFörarens hunger: {_driver.Hunger}";

            return output;
        }

        private void TurnLeft()
        {
            switch (_car.Direction)
            {
                case "Norrut":
                    _car.Direction = "Västerut";
                    break;

                case "Söderut":
                    _car.Direction = "Österut";
                    break;

                case "Västerut":
                    _car.Direction = "Söderut";
                    break;

                case "Österut":
                    _car.Direction = "Norrut";
                    break;
            }
        }

        private void TurnRight()
        {
            switch (_car.Direction)
            {
                case "Norrut":
                    _car.Direction = "Österut";
                    break;

                case "Söderut":
                    _car.Direction = "Västerut";
                    break;

                case "Västerut":
                    _car.Direction = "Norrut";
                    break;

                case "Österut":
                    _car.Direction = "Söderut";
                    break;
            }
        }
    }
}

