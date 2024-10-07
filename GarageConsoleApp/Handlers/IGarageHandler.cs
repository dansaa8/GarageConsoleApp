using GarageConsoleApp.Entities.Garage;
using GarageConsoleApp.Entities.Vehicle;
using GarageConsoleApp.Services;

namespace GarageConsoleApp.Handlers;

public interface IGarageHandler<T> where T : IVehicle
{
    bool AddVehicle(Garage<T> garage, T vehicle);
    string RemoveVehicle(Garage<T> garage, string vehicleRegNr);
    bool IsGarageFull(Garage<T> garage);
    List<string> ListAllVehicles(Garage<T> garage);
    string ListAllVehicleTypes(Garage<T> garage);
    List<string> SearchVehicles(Garage<T> garage, SearchOptions searchOptions);
}