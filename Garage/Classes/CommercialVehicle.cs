using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Classes
{
    public class CommercialVehicle
    {
        public int TowingWeight { get; set; }

        public CommercialVehicle(int towingweight)
        {
            this.TowingWeight = towingweight;
        }
    }
}
