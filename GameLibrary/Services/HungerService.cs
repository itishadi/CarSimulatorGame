using GameLibrary.Models;

namespace GameLibrary.Services
{
    public class HungerService : IHungerService
    {
        private Driver _driver;

        public HungerService(Driver driver)
        {
            _driver = driver;
        }
        public void IncreaseHunger()
        {
            switch (_driver.Hunger)
            {
                case Hunger.Full:
                    _driver.Hunger = Hunger.NotHungry;
                    break;
                case Hunger.NotHungry:
                    _driver.Hunger = Hunger.SoonHungry;
                    break;

                case Hunger.SoonHungry:
                    _driver.Hunger = Hunger.Hungry;
                    break;

                case Hunger.Hungry:
                    _driver.Hunger = Hunger.VeryHungry;
                    break;
                case Hunger.VeryHungry:
                    _driver.Hunger = Hunger.VeryHungry;
                    break;
            }
        }
        public void ResetHunger()
        {
            _driver.Hunger = Hunger.Full;
        }
    }
}
