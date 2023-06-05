//namespace GameLibrary.Models
//{
//    public class Driver
//    {
//        public string Name { get; set; }
//        public int Fatigue { get; set; }
//        public Car Cars { get; set; }
//        public Driver()
//        {
//            Name = "John Doe";
//            Fatigue = 0;
//        }
//    }
//}
namespace GameLibrary.Models
{
    public enum Hunger
    {
        Full = 0,
        Hungry = 1,
        VeryHungry = 2
    }

    public class Driver
    {
        public string Name { get; set; }
        public int Fatigue { get; set; }
        public Car Cars { get; set; }
        public Hunger Hunger { get; set; }

        public Driver()
        {
            Name = "John Doe";
            Fatigue = 0;
            Hunger = Hunger.Full;
        }

        public void IncreaseFatigue()
        {
            Fatigue++;
        }
    }
}

