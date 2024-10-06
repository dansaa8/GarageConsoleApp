using System.Drawing;
using GarageConsoleApp.Entities;
using GarageConsoleApp.Entities.Vehicle;

namespace GarageConsoleApp.Services;

public struct SearchOptions
{
    public string? RegistrationNumber { get; set; }
    
    public uint? WheelCount { get; set; }
    
    public Color? Color { get; set; }
    
    public VehicleType? VehicleType { get; set; }
}