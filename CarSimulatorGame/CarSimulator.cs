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
    private IMenuService menuService;

    public CarSimulator()
    {
        driver = new Driver();
        car = new Car();
        commandService = new CommandService(driver, car);
        apiService = new ApiService();
        menuService = new MenuService(driver, car, commandService, apiService); 
    }

    public async Task Start()
    {

        while (true) { 

        Console.Clear();

        Console.WriteLine("Welcome to Car Simulator!");
        Console.WriteLine("1: Start Game");
        Console.WriteLine("2: End");

        var answer = Console.ReadLine();

        if (answer == "1")
        {
        await menuService.Start();
        }
        else if (answer == "2")
        {
                break;
        }
        else
        {
            Console.WriteLine("Wrong answer, try again!");
        }
            break;
        }
    }
}



