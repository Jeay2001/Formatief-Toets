using System;
using System.Collections.Generic;
using Garage.Classes;

namespace Garage
{
    class Program
    {
        static void Main(string[] args)
        {
            
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Garage Management System");
                Console.WriteLine("1. Add Owner");
                Console.WriteLine("2. Add Vehicle to Owner");
                Console.WriteLine("3. Change License Plate");
                Console.WriteLine("4. View Owners and Vehicles");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddOwner();
                        break;
                    case "2":
                        AddVehicleToOwner();
                        break;
                    case "3":
                        ChangeLicensePlate();
                        break;
                    case "4":
                        ViewOwnersAndVehicles();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        static void AddOwner()
        {
            Console.Clear();
            Console.Write("Enter owner's name: ");
            string name = Console.ReadLine();
            CarOwner owner = new CarOwner(1, name);
            owner.AddOwner();
            Console.WriteLine("Owner added successfully.\n");
            Console.Clear();
        }

        static void AddVehicleToOwner()
        {
            Console.Clear();
            List<CarOwner> owners = CarOwner.GetOwner();
            Console.WriteLine("Select an owner by number:");
            foreach (CarOwner owner in owners)
            {
                Console.WriteLine($"{owner.Id}. {owner.Name}");
            }

            string ownerChoice = Console.ReadLine();
            int selectedOwnerId;
            if (!int.TryParse(ownerChoice, out selectedOwnerId))
            {
                Console.WriteLine("Invalid owner ID. Please try again.\n");
                return;
            }

            CarOwner selectedOwner = owners.FirstOrDefault(owner => owner.Id == selectedOwnerId);
            while (selectedOwner == null)
            {
                Console.WriteLine("Owner not found. Please try again.\n");
                ownerChoice = Console.ReadLine();
                if (!int.TryParse(ownerChoice, out selectedOwnerId))
                {
                    Console.WriteLine("Invalid owner ID. Please try again.\n");
                    return;
                }
                selectedOwner = owners.FirstOrDefault(owner => owner.Id == selectedOwnerId);
            }

            Console.WriteLine("Select a vehicle to add to the owner:");
            List<Vehicle> vehicles = Vehicle.GetVehicle();
            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine($"{vehicle.Id}. Description: {vehicle.Description}, Licenseplate: {vehicle.LicensePlate}, Type: {vehicle.Type}");
            }

            string vehicleChoice = Console.ReadLine();
            int selectedVehicleId;
            if (!int.TryParse(vehicleChoice, out selectedVehicleId))
            {
                Console.WriteLine("Invalid vehicle ID. Please try again.\n");
                return;
            }

            Vehicle selectedVehicle = vehicles.FirstOrDefault(vehicle => vehicle.Id == selectedVehicleId);
            while (selectedVehicle == null)
            {
                Console.WriteLine("Vehicle not found. Please try again.\n");
                vehicleChoice = Console.ReadLine();
                if (!int.TryParse(vehicleChoice, out selectedVehicleId))
                {
                    Console.WriteLine("Invalid vehicle ID. Please try again.\n");
                    return;
                }
                selectedVehicle = vehicles.FirstOrDefault(vehicle => vehicle.Id == selectedVehicleId);
            }

            // Add the selected vehicle to the selected owner
            selectedOwner.AddCarToOwner(selectedVehicleId);
            Console.WriteLine("Vehicle added successfully.\n");
            Console.Clear();
        }

        static void ChangeLicensePlate()
        {
            Console.Clear();
            Console.WriteLine("Select a vehicle to change the license plate:");
            List<Vehicle> vehicles = Vehicle.GetVehicle();
            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine($"{vehicle.Id}. Description: {vehicle.Description}, Licenseplate: {vehicle.LicensePlate}, Type: {vehicle.Type}");
            }

            string vehicleChoice = Console.ReadLine();
            int selectedVehicleId;
            if (!int.TryParse(vehicleChoice, out selectedVehicleId))
            {
                Console.WriteLine("Invalid vehicle ID. Please try again.\n");
                return;
            }

            Vehicle selectedVehicle = vehicles.FirstOrDefault(vehicle => vehicle.Id == selectedVehicleId);
            while (selectedVehicle == null)
            {
                Console.WriteLine("Vehicle not found. Please try again.\n");
                vehicleChoice = Console.ReadLine();
                if (!int.TryParse(vehicleChoice, out selectedVehicleId))
                {
                    Console.WriteLine("Invalid vehicle ID. Please try again.\n");
                    return;
                }
                selectedVehicle = vehicles.FirstOrDefault(vehicle => vehicle.Id == selectedVehicleId);
            }

            string newLicensePlate;
            bool isValidLicensePlate = false;

            while (!isValidLicensePlate)
            {
                Console.WriteLine($"Current license plate: {selectedVehicle.LicensePlate}");
                Console.Write("Enter new license plate: ");
                newLicensePlate = Console.ReadLine();
                Console.Clear();
                


                // Validate the new license plate based on vehicle type
                if (selectedVehicle.Type == "Bedrijfswagen")
                {
                    // Ensure it starts with "V" and has the correct format
                    if (newLicensePlate.Length == 10 && newLicensePlate.StartsWith("V") && newLicensePlate[2] == '-' && newLicensePlate[7] == '-')
                    {
                        selectedVehicle.ChangeLicensePlate(newLicensePlate);
                        isValidLicensePlate = true;
                        Console.WriteLine("License plate changed successfully.\n");
                    }
                    else
                    {
                        Console.WriteLine("Invalid license plate format for a Bedrijfswagen. It must start with 'V' and follow the format Vx-xxxx-xX.\n");
                        
                    }
                }
                else if (selectedVehicle.Type == "Persoon")
                {
                    // Ensure it has the correct format for a regular vehicle
                    if (newLicensePlate.Length == 10 && newLicensePlate[2] == '-' && newLicensePlate[7] == '-')
                    {
                        selectedVehicle.ChangeLicensePlate(newLicensePlate);
                        isValidLicensePlate = true;
                        Console.WriteLine("License plate changed successfully.\n");
                    }
                    else
                    {
                        
                        Console.WriteLine("Invalid license plate format for a Persoon. It must follow the format xx-xxxx-xx.\n");
                        
                    }
                }
                else
                {
                    Console.WriteLine("Unknown vehicle type.\n");
                    return;
                }


            }

        }

        static void ViewOwnersAndVehicles()
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.Clear();
                Console.WriteLine("Owners");
                List<CarOwner> owners = CarOwner.GetOwner();
                foreach (CarOwner owner in owners)
                {
                    Console.WriteLine($"{owner.Id}. {owner.Name}");
                }
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Vehicles");
                List<Vehicle> vehicles = Vehicle.GetVehicle();
                foreach (Vehicle vehicle in vehicles)
                {
                    Console.WriteLine($"{vehicle.Id}. Description: {vehicle.Description}, Licenseplate: {vehicle.LicensePlate}, Type: {vehicle.Type}");
                }

                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Options:");
                Console.WriteLine("1. Add New Vehicle");
                Console.WriteLine("2. Remove Vehicle");
                Console.WriteLine("3. Return to Main Menu");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Add New Vehicle Logic
                        Console.Clear();
                        Console.WriteLine("Enter the vehicle description:");
                        string description = Console.ReadLine();

                        Console.WriteLine("Select the type of vehicle:");
                        Console.WriteLine("1. Persoon");
                        Console.WriteLine("2. Bedrijfswagen");
                        string typeChoice = Console.ReadLine();

                        bool isValidLicensePlate = false;
                        string newLicensePlate = "";

                        while (!isValidLicensePlate)
                        {
                            Console.WriteLine("Enter the new license plate:");
                            newLicensePlate = Console.ReadLine(); // Prompt for license plate inside the loop

                            // Validate the new license plate based on vehicle type
                            if (typeChoice == "2")
                            {
                                // Ensure it starts with "V" and has the correct format
                                if (newLicensePlate.Length == 10 && newLicensePlate.StartsWith("V") && newLicensePlate[2] == '-' && newLicensePlate[7] == '-')
                                {
                                    isValidLicensePlate = true;
                                    Console.WriteLine("License plate added correctly.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid license plate format for a Bedrijfswagen. It must start with 'V' and follow the format Vx-xxxx-xX.\n");
                                }
                            }
                            else if (typeChoice == "1")
                            {
                                // Ensure it has the correct format for a regular vehicle
                                if (newLicensePlate.Length == 10 && newLicensePlate[2] == '-' && newLicensePlate[7] == '-')
                                {
                                    isValidLicensePlate = true;
                                    Console.WriteLine("License plate added correctly.\n");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid license plate format for a Persoon. It must follow the format xx-xxxx-xx.\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid type selection. Please try again.");
                                break;
                            }
                        }

                        int towingWeight = 0;

                        if (typeChoice == "1")
                        {
                            // Create a regular vehicle
                            Vehicle newVehicle = new Vehicle(1, description, newLicensePlate, "Persoon");
                            newVehicle.AddVehicle();  // Call the method to add the regular vehicle to the database
                            Console.WriteLine("New regular vehicle added successfully.\n");
                        }
                        else if (typeChoice == "2")
                        {
                            // Create a commercial vehicle
                            Console.WriteLine("Enter the towing weight:");
                            if (!int.TryParse(Console.ReadLine(), out towingWeight))
                            {
                                Console.WriteLine("Invalid towing weight. Please try again.");
                                break;
                            }

                            CommercialVehicle newCommercialVehicle = new CommercialVehicle(1, description, newLicensePlate, "Bedrijfswagen", towingWeight);
                            newCommercialVehicle.AddCoomercialVehicle();  // Call the method to add the commercial vehicle to the database
                            Console.WriteLine("New commercial vehicle added successfully.\n");
                        }

                        break;


                    case "2":
                        // Remove Vehicle Logic
                        Console.Clear();
                        Console.WriteLine("Select a vehicle to remove:");

                        foreach (Vehicle vehicle in vehicles)
                        {
                            Console.WriteLine($"{vehicle.Id}. Description: {vehicle.Description}, Licenseplate: {vehicle.LicensePlate}, Type: {vehicle.Type}");
                        }

                        Console.Write("Enter the vehicle ID to remove: ");
                        int vehicleId;
                        if (!int.TryParse(Console.ReadLine(), out vehicleId))
                        {
                            Console.WriteLine("Invalid vehicle ID. Please try again.");
                            break;
                        }

                        Vehicle selectedVehicle = vehicles.FirstOrDefault(v => v.Id == vehicleId);
                        if (selectedVehicle == null)
                        {
                            Console.WriteLine("Vehicle not found. Please try again.");
                            break;
                        }
                        selectedVehicle.RemoveVehicle();
                        Console.WriteLine("Vehicle removed successfully.\n");
                        break;

                    case "3":
                        continueRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        
    }
}
