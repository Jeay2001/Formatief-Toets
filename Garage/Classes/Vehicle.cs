using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.DataAccessLayer;

namespace Garage.Classes
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string LicensePlate { get; set; }
        public string Type { get; set; }
        public List<CommercialVehicle> CommercialVehicles { get; set; }
        public List<CarOwner> CarOwners { get; set; }

        public Vehicle(int id, string? description, string licenseplate, string type)
        {
            this.Id = id;
            this.Description = description;
            this.LicensePlate = licenseplate;
            this.Type = type;
        }

        public static List<Vehicle> GetVehicle()
        {
            DAL dal = new DAL();
            List<Vehicle> vehicles = dal.GetVehicle();
            return vehicles;
        }
        public void AddVehicle()
        {
            DAL dal = new DAL();
            dal.AddVehicle(this);
        }
        public void RemoveVehicle()
        {
            DAL dal = new DAL();
            dal.RemoveVehicle(this);
        }
        public void ChangeLicensePlate(string newLicensePlate)
        {
            DAL dal = new DAL();
            dal.ChangeLicensePlate(this.Id, newLicensePlate);
            this.LicensePlate = newLicensePlate;
        }
    }
}
