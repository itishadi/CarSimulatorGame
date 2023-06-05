using GameLibrary.Models;

namespace GameLibrary.Services
{
    public class CarSimulatorService : ICarSimulatorService
    {
        private readonly Driver driver;
        public CarSimulatorService()
        {
            driver = new Driver
            {
                Name = "John Doe",
                Fatigue = 1,
                Cars = new Car
                {
                    Direction = "Norrut, spelet startas alltid norrut!",
                    Fuel = 20
                }
            };
        }
        public Driver GetDriver()
        {
            return driver;
        }
    }
}
