using System.Text;
using GarageConsoleApp.Entities;
using GarageConsoleApp.Entities.Garage;

namespace GarageConsoleApp.Services;

public class GarageHandler<T> where T : Vehicle
{
    public bool AddVehicle(Garage<T> garage, T vehicle)
    {
        return garage.Add(vehicle);
    }
    
    public string RemoveVehicle(Garage<T> garage, string vehicleRegNr)
    {
        T? removedVehicle = garage.RemoveByRegNumber(vehicleRegNr);
        return removedVehicle?.ToString() ?? string.Empty;
    }
    
    public bool IsGarageFull(Garage<T> garage)
    {
        return !garage.HasEmptySpots();
    }

    public List<string> ListAllVehicles(Garage<T> garage)
    {
        List<String> allVehicles = new();
        foreach (T vehicle in garage)
        {
            allVehicles.Add(vehicle.ToString());
        }

        return allVehicles;
    }

    public string ListAllVehicleTypes(Garage<T> garage)
    {
        uint carCount = 0;
        uint boatCount = 0;
        uint mcCount = 0;
        foreach (T vehicle in garage)
        {
            if (vehicle is Car car) carCount++;
            if (vehicle is Boat boat) boatCount++;
            if (vehicle is Motorcycle) mcCount++;
        }

        // Create list with tuples
        var vehicleCounts = new List<(string Type, uint Count)>();

        // Only add the types to the tuple list if they are over 0
        if (carCount > 0) vehicleCounts.Add(("Cars", carCount));
        if (boatCount > 0) vehicleCounts.Add(("Boats", boatCount));
        if (mcCount > 0) vehicleCounts.Add(("Motorcycles", mcCount));

        vehicleCounts = vehicleCounts
            .OrderByDescending(v => v.Count) // Sort tuplelist: highest count first
            .ThenBy(v => v.Type) // Sort tuplelist: alphabetically if the above results in a tie
            .ToList();

        StringBuilder result = new StringBuilder();
        foreach (var (VehicleType, Count) in vehicleCounts) // Iterate over all tuples in List
        {
            result.AppendLine($"{VehicleType}: {Count}"); // Append each item in list to the stringbuilder
        }

        return result.ToString().Trim(); // Remove any trailing spaces
    }

    public List<string> SearchVehicles(Garage<T> garage, SearchOptions searchOptions)
    {
        List<string> foundVehicles = new();
        foreach (T vehicle in garage)
        {
            // ? checks if the property is null. If it is null, then the expression stops here
            // and the value after ?? is used. Which means it's not a search criteria to look for.
            if ((searchOptions.RegistrationNumber?
                    .Equals(vehicle.RegistrationNumber, StringComparison.OrdinalIgnoreCase) ?? true) &&
                (searchOptions.WheelCount?
                    .Equals(vehicle.WheelCount) ?? true) &&
                (searchOptions.Color?
                    .Equals(vehicle.Color) ?? true) &&
                (searchOptions.VehicleType?.ToString()
                    .Equals(vehicle.GetType().Name, StringComparison.OrdinalIgnoreCase) ?? true))
            {
                foundVehicles.Add(vehicle.ToString());
            }
        }

        return foundVehicles;
    }
}