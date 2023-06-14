using GameLibrary.Services;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameLibrary.Tests
{
    public class HungerServiceConsumer
    {
        private readonly IHungerService _hungerService;

        public HungerServiceConsumer(IHungerService hungerService)
        {
            _hungerService = hungerService;
        }

        public void IncreaseHunger()
        {
            _hungerService.IncreaseHunger();
        }

        public void ResetHunger()
        {
            _hungerService.ResetHunger();
        }
    }

    [TestClass]
    public class HungerServiceTests
    {
        private Mock<IHungerService> _hungerService;

        [TestInitialize]
        public void Setup()
        {
            _hungerService = new Mock<IHungerService>();
        }

        [TestMethod]
        public void IncreaseHunger_ShouldCallIncreaseHungerMethod()
        {
            // Arrange
            var hungerServiceConsumer = new HungerServiceConsumer(_hungerService.Object);

            // Act
            hungerServiceConsumer.IncreaseHunger();

            // Assert
            _hungerService.Verify(x => x.IncreaseHunger(), Times.Once);
        }

        [TestMethod]
        public void ResetHunger_ShouldCallResetHungerMethod()
        {
            // Arrange
            var hungerServiceConsumer = new HungerServiceConsumer(_hungerService.Object);

            // Act
            hungerServiceConsumer.ResetHunger();

            // Assert
            _hungerService.Verify(x => x.ResetHunger(), Times.Once);
        }
    }
}
