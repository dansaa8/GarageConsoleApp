using GarageConsoleApp.Entities;

namespace GarageConsoleApp.Services;

public struct SearchOptions
{
    public string? RegistrationNumber { get; set; }
    
    public int? WheelCount { get; set; }
    
    public VehicleColor? Color { get; set; }
    
    public VehicleType? VehicleType { get; set; }
}