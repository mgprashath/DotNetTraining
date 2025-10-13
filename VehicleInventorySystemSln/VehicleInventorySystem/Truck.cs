using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventorySystem
{
    internal class Truck : Vehicle
    {
        public double LoadCapacity { get; set; }

        public Truck(string make, string model, short modelYear, double loadCapacity) : base(make, model, modelYear)
        {
            LoadCapacity = loadCapacity;
        }

        public override string DisplayInfo()
        {
            return $"{base.DisplayInfo()} Load Capacity:{LoadCapacity}";
        }
    }
}
