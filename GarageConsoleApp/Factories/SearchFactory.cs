using System.Drawing;
using GarageConsoleApp.Entities;
using GarageConsoleApp.Services;

namespace GarageConsoleApp.Handlers;

// Factory method used to create a struct of searchoptions from user input
public static class SearchFactory
{
    public static SearchOptions CreateVehicleSearch()
    {
        SearchOptions searchOptions = new();
        searchOptions.RegistrationNumber = InputHandler.GetRegistrationNumber(true);
        searchOptions.WheelCount = InputHandler.GetWheelCount(true);
        searchOptions.Color = InputHandler.GetColor(true);
        searchOptions.VehicleType = InputHandler.GetVehicleType(true);

        return searchOptions;
    }
}