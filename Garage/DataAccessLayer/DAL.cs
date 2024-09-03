using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Classes;

namespace Garage.DataAccessLayer
{
    public class DAL
    {
        private string connectionString = "Data Source=.;Initial Catalog=Garage;Integrated Security=true";
        public void AddOwner(CarOwner carowner)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO CarOwner (Name) VALUES (@Name)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", carowner.Name);
                command.ExecuteNonQuery();
            }
        }
        public List<CarOwner> GetOwner()
        {
            List<CarOwner> carowners = new List<CarOwner>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM CarOwner";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CarOwner carowner = new CarOwner(reader.GetInt32(0), reader.GetString(1));
                    carowners.Add(carowner);
                }
            }
            return carowners;
        }
        public void AddCarToOwner(int vehicleId, int ownerId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE Vehicle SET OwnerId = @OwnerId WHERE Id = @VehicleId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OwnerId", ownerId);
                    cmd.Parameters.AddWithValue("@VehicleId", vehicleId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Vehicle assigned to owner successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Error: Vehicle not found or could not be updated.");
                    }
                }
            }
        }
        public void RemoveCar(CarOwner carowner)
        {
        }
        public void ChangeLicensePlate(int vehicleId, string newLicensePlate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE Vehicle SET Licenseplate = @NewLicensePlate WHERE Id = @VehicleId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NewLicensePlate", newLicensePlate);
                    cmd.Parameters.AddWithValue("@VehicleId", vehicleId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    
                }
            }
        }
        public void AddCommecrialCarToOwner(CommercialVehicle commercialVehicle)
        {
        }
        public void RegisterTowingWeight(CommercialVehicle commercialVehicle)
        {
        }

        public List<Vehicle> GetVehicle()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Vehicle";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string licensePlate = reader.GetString(1);
                    string description = reader.GetString(2);
                    string typeId = reader.GetString(3);
                    if (typeId == "Persoon")
                    {
                        Vehicle vehicle = new Vehicle(id, licensePlate, description, typeId);
                        vehicles.Add(vehicle);
                    }
                    else if (typeId == "Bedrijfswagen")
                    {
                        int TowingWeight = reader.GetInt32(5);
                        CommercialVehicle vehicle = new CommercialVehicle(id, licensePlate, description, typeId, TowingWeight);
                        vehicles.Add(vehicle);
                    }
                    
                }
                return vehicles;
            }
        }
        public void AddVehicle(Vehicle vehicle)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Vehicle (Description, Licenseplate, Type) VALUES (@Description, @Licenseplate, @Type)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                    cmd.Parameters.AddWithValue("@Licenseplate", vehicle.LicensePlate);
                    cmd.Parameters.AddWithValue("@Type", vehicle.Type);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Method to add a commercial vehicle
        public void AddCommercialVehicle(CommercialVehicle commercialVehicle)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Vehicle (Description, Licenseplate, Type, TowingWeight) VALUES (@Description, @Licenseplate, @Type, @TowingWeight)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Description", commercialVehicle.Description);
                    cmd.Parameters.AddWithValue("@Licenseplate", commercialVehicle.LicensePlate);
                    cmd.Parameters.AddWithValue("@Type", commercialVehicle.Type);
                    cmd.Parameters.AddWithValue("@TowingWeight", commercialVehicle.TowingWeight);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void RemoveVehicle(Vehicle vehicle)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM Vehicle WHERE Id = @VehicleId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@VehicleId", vehicle.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }




    }
}
