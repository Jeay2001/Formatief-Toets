using Garage.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Classes
{
    public class CommercialVehicle : Vehicle
    {
        public int TowingWeight { get; set; }

        public CommercialVehicle(int id, string? description,string licenseplate,string type, int towingweight) 
            : base(id, description, licenseplate, type)
        {
            this.TowingWeight = towingweight;
        }

        public void AddCommecrialCarToOwner()
        {
            DAL dal = new DAL();
            dal.AddCommecrialCarToOwner(this);
        }
        public void AddCoomercialVehicle()
        {
            DAL dal = new DAL();
            dal.AddCommercialVehicle(this);
        }
        public void RegisterTowingWeight()
        {
            DAL dal = new DAL();
            dal.RegisterTowingWeight(this);
        }
    }
}
