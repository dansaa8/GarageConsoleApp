using System.Text;
using GarageConsoleApp.Entities;
using GarageConsoleApp.Entities.Garage;

namespace GarageConsoleApp.Services;

public class GarageHandler<T> where T : Vehicle
{
    public string RemoveVehicle(Garage<T> garage, string vehicleRegNr)
    {
        T? removedVehicle = garage.RemoveByRegNumber(vehicleRegNr);
        return removedVehicle?.ToString() ?? string.Empty;
    }

    public string ListAllVehicles(Garage<T> garage)
    {
        StringBuilder allVehicles = new StringBuilder();
        foreach (T vehicle in garage)
        {
            allVehicles.AppendLine(vehicle.ToString());
        }

        return allVehicles.ToString().Trim(); // Trim() Removes last AppendLine
    }
}