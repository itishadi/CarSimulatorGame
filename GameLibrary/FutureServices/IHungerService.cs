using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.FutureServices
{
    public interface IHungerService
    {
        void IncreaseHunger();
        int HungerLevel { get; }
    }
}
