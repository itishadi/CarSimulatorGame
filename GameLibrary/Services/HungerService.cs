using GameLibrary.Models;

namespace GameLibrary.Services
{
    public class HungerService
    {
        private Driver driver;

        public HungerService(Driver driver)
        {
            this.driver = driver;
        }

        public void IncreaseHunger()
        {
            switch (driver.Hunger)
            {
                case Hunger.Full:
                    driver.Hunger = Hunger.Hungry;
                    break;
                case Hunger.Hungry:
                    driver.Hunger = Hunger.VeryHungry;
                    break;
                case Hunger.VeryHungry:
                    driver.Hunger = Hunger.VeryHungry;
                    break;
            }
        }

        public void ResetHunger()
        {
            driver.Hunger = Hunger.Full;
        }
    }
}
