using System.Drawing;

namespace GarageConsoleApp.Entities.Vehicle;

public interface IVehicle : ICloneable
{
    string RegistrationNumber { get; }
    uint WheelCount { get; }
    Color Color { get; }
    object Clone();
    string ToString();
}