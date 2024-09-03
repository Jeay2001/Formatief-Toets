using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.DataAccessLayer;


namespace Garage.Classes
{
    public class CarOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CarOwner(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public void AddOwner()
        {
            DAL dal = new DAL();
            dal.AddOwner(this);
        }

        public void AddCarToOwner(int vehicleId)
        {
            DAL dal = new DAL();
            dal.AddCarToOwner(vehicleId, this.Id);
        }


        public static List<CarOwner> GetOwner()
        {
            DAL dal = new DAL();
            List<CarOwner> carowners = dal.GetOwner();
            return carowners;

        }
    }
}
