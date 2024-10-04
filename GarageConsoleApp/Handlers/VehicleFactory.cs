using System.Drawing;
using GarageConsoleApp.Entities;

namespace GarageConsoleApp.Handlers;

public static class VehicleFactory
{
    public static Vehicle CreateVehicle()
    {
        VehicleType type = InputHandler.GetVehicleType(false).Value;
        string regNr = InputHandler.GetRegistrationNumber(false);
        uint wheelCount = InputHandler.GetWheelCount(false).Value;
        Color color = InputHandler.GetColor(false).Value;

        return type switch
        {
            VehicleType.Car => new Car
                (regNr, wheelCount, color, InputHandler.GetIsAutomatic(false).Value),
            VehicleType.Boat => new Boat
                (regNr, wheelCount, color, InputHandler.GetMaxKnots(false).Value),
            VehicleType.Motorcycle => new Motorcycle
                (regNr, wheelCount, color, InputHandler.GetMaxSpeed(false).Value),
            _ => throw new InvalidOperationException($"Vehicle type {type} is not supported.")
        };
    }
}