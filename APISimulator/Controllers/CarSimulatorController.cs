using GameLibrary.Models;
using GameLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APISimulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarSimulatorController : ControllerBase
    {
        private readonly ICarSimulatorService carSimulatorService;

        public CarSimulatorController(ICarSimulatorService carSimulatorService)
        {
            this.carSimulatorService = carSimulatorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Driver driver = carSimulatorService.GetDriver();
            return Ok(driver);
        }
    }
}
