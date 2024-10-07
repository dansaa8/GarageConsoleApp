using GarageConsoleApp.Entities.Garage;
using GarageConsoleApp.Entities.Vehicle;

namespace GarageConsoleApp.UI;

public interface IUI
{
    void ListVehicles(Garage<IVehicle> garage);
    void ListVehicleTypes(Garage<IVehicle> garage);
    void AddVehicle(Garage<IVehicle> garage);
    void RemoveVehicle(Garage<IVehicle> garage);
    void SearchVehicles(Garage<IVehicle> garage);
    void CreateNewGarage(List<Garage<IVehicle>> garageList);
}