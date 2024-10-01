namespace GarageConsoleApp.Entities;

public class Motorcycle : Vehicle
{
    public double MaxSpeedKmPerHour { get; }

    public Motorcycle(string registrationNumber, int wheelCount, VehicleColor color, double maxSpeedKmPerHour) : base(
        registrationNumber, wheelCount, color)
    {
        MaxSpeedKmPerHour = maxSpeedKmPerHour;
    }
}