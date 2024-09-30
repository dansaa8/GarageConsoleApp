namespace GarageConsoleApp.Entities;

public abstract class Vehicle
{
    public string RegistrationNumber { get; set; }
    public int WheelCount { get; set; }
    public VehicleColor Color { get; set; }

    protected Vehicle(string registrationNumber, int wheelCount, VehicleColor color)
    {
        RegistrationNumber = registrationNumber;
        WheelCount = wheelCount;
        Color = color;
    }
}