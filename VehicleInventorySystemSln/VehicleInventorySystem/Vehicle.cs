using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventorySystem
{
    internal class Vehicle
    {
        public string Make { get; set; }= string.Empty;
        public string Model { get; set; } = string.Empty;
        public short ModelYear { get; set; }

        public Vehicle(string make, string model, short modelYear)
        {
            Make = make;
            Model=model; 
            ModelYear = modelYear;
        }

        public virtual string DisplayInfo()
        {
            return $"Make:{Make} Model:{Model} Year:{ModelYear}";
        }
    }
}
