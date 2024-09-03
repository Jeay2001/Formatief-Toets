using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Classes
{
    public class CarOwner
    {
        public string Name { get; set; }

        public CarOwner(string name)
        {
            this.Name = name;
        }
    }
}
