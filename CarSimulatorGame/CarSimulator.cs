using GameLibrary.Models;
using GameLibrary.Services;
using System;
using System.Threading.Tasks;

public class CarSimulator
{
    private Driver driver;
    private Car car;
    private CommandService commandService;
    private ApiService apiService;
    private FatigueService fatigueService;
    private IMenuService menuService;

    public CarSimulator()
    {
        driver = new Driver();
        car = new Car();
        commandService = new CommandService(driver, car);
        apiService = new ApiService();
        fatigueService = new FatigueService(driver, car, commandService, apiService);
        menuService = new MenuService(driver, car, commandService, apiService, fatigueService);
    }

    public async Task StartMenu()
    {
        await menuService.Start();
    }
}

