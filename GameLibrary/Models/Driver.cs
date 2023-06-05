namespace GameLibrary.Models
{
    public class Driver
    {
        public string Name { get; set; }
        public int Fatigue { get; set; }
        public Car Cars { get; set; }
        public Driver()
        {
            Name = "John Doe";
            Fatigue = 0;
        }
    }
}
