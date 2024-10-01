namespace GarageConsoleApp.Entities;

public abstract class Vehicle
{
    public string RegistrationNumber { get; }
    public int WheelCount { get; }
    public VehicleColor Color { get; }

    protected Vehicle(string registrationNumber, int wheelCount, VehicleColor color)
    {
        RegistrationNumber = registrationNumber;
        WheelCount = wheelCount;
        Color = color;
    }
}