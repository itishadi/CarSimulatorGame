using GameLibrary.Models;

namespace GameLibrary.Services
{
    public class CommandService
    {
        private Driver driver;
        private Car car;
        private HungerService hungerService;

        public CommandService(Driver driver, Car car)
        {
            this.driver = driver;
            this.car = car;
            hungerService = new HungerService(driver);
        }

        public string ExecuteCommand(string input)
        {
            string output = "";

            switch (input.ToLower())
            {
                case "1":
                case "sväng vänster":
                    if (car.Fuel >= 1)
                    {
                        car.Fuel -= 1;
                        TurnLeft();
                        output = "Bilföraren svänger vänster.";
                        driver.IncreaseFatigue();
                        hungerService.IncreaseHunger();
                    }
                    else
                    {
                        output = "Bilen har inte tillräckligt med bensin för att köra framåt.";
                    }
                    break;

                case "2":
                case "sväng höger":
                    if (car.Fuel >= 1)
                    {
                        car.Fuel -= 1;
                        TurnRight();
                        output = "Bilföraren svänger höger.";
                        driver.IncreaseFatigue();
                        hungerService.IncreaseHunger();
                    }
                    else
                    {
                        output = "Bilen har inte tillräckligt med bensin för att köra framåt.";
                    }
                    break;

                case "3":
                case "köra framåt":
                    if (car.Fuel >= 1)
                    {
                        car.Fuel -= 1;

                        output = "Bilföraren kör framåt.";
                        driver.IncreaseFatigue();
                        hungerService.IncreaseHunger();
                    }
                    else
                    {
                        output = "Bilen har inte tillräckligt med bensin för att köra framåt.";
                    }
                    break;

                case "4":
                case "backa":
                    if (car.Fuel >= 1)
                    {
                        car.Fuel -= 1;

                        output = "Bilföraren backar.";
                        driver.IncreaseFatigue();
                        hungerService.IncreaseHunger();
                    }
                    else
                    {
                        output = "Bilen har inte tillräckligt med bensin för att köra framåt.";
                    }
                    break;

                case "5":
                case "rasta":
                    driver.Fatigue = 1;
                    output = "Bilföraren tar en paus och vilar.";
                    hungerService.ResetHunger();
                    break;

                case "6":
                case "tanka bilen":
                    car.Fuel = 20;
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

            output += $"\nBilens riktning: {car.Direction}";
            output += $"\nBensin: {car.Fuel}/20";
            output += $"\nFörarens trötthet: {driver.Fatigue}/10";
            output += $"\nFörarens hunger: {driver.Hunger}";

            return output;
        }

        private void TurnLeft()
        {
            switch (car.Direction)
            {
                case "Norrut":
                    car.Direction = "Västerut";
                    break;

                case "Söderut":
                    car.Direction = "Österut";
                    break;

                case "Västerut":
                    car.Direction = "Söderut";
                    break;

                case "Österut":
                    car.Direction = "Norrut";
                    break;
            }
        }

        private void TurnRight()
        {
            switch (car.Direction)
            {
                case "Norrut":
                    car.Direction = "Österut";
                    break;

                case "Söderut":
                    car.Direction = "Västerut";
                    break;

                case "Västerut":
                    car.Direction = "Norrut";
                    break;

                case "Österut":
                    car.Direction = "Söderut";
                    break;
            }
        }
    }
}

