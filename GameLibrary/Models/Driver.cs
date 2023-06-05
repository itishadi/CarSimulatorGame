namespace GameLibrary.Models
{
    public class Driver
    {
        public string Name { get; set; }
        public int DistanceDriven { get; set; }
        public int Fatigue { get; set; }

        public Driver()
        {
            Name = "John Doe";
            DistanceDriven = 0;
            Fatigue = 0;
        }
    }
}
