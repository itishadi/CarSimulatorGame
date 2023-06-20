namespace GameLibrary.Models
{
    public class Driver
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Fatigue { get; set; }
        public void IncreaseFatigue()
        {
            Fatigue++;
        }
    }
}

