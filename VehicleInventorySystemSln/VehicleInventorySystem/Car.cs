using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventorySystem
{
    internal class Car : Vehicle
    {
        public int Doors { get; set; }

        public Car(string make, string model, short modelYear, int doors) :base(make, model, modelYear)
        {
            Doors = doors;
        }

        public override string DisplayInfo()
        {
            return $"{base.DisplayInfo()} Num of Doors:{Doors}";
        }
    }
}
