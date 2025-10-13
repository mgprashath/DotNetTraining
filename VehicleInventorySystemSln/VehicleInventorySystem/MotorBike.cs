using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventorySystem
{
    internal class MotorBike : Vehicle
    {
        public bool HasSidecar { get; set; }

        public MotorBike(string make, string model, short modelYear, bool hasSidecar) : base(make, model, modelYear)
        {
            HasSidecar = hasSidecar;
        }

        public override string DisplayInfo()
        {
            return $"{base.DisplayInfo()} Has a Side car:{(HasSidecar ? "yes":"No")}";
        }
    }   
}
