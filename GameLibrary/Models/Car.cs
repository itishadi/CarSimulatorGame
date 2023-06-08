namespace GameLibrary.Models
{
    public class Car
    {
        public string Direction { get; set; }
        public int Fuel { get; set; }
        public Car()
        {
            Direction = "Northward";
            Fuel = 20;
        }
    }
}
