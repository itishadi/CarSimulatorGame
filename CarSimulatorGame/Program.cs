using CarSimulatorGame;
using GameLibrary.Services;
using System.Runtime.CompilerServices;

class Program
{
    static async Task Main(string[] args)
    {
        CarSimulator carSimulator = new CarSimulator();
        await carSimulator.Start();
    }
}
