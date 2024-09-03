using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Classes
{
    public abstract class Vehicle
    {
        public string? Description { get; set; }
        public string LicensePlate { get; set; }

        public Vehicle(string? Description, string licensePlate)
        {
            this.Description = Description;
            this.LicensePlate = licensePlate;
        }
    }
}
