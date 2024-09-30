namespace GarageConsoleApp.Entities;

public class Boat : Vehicle
{
    public double MaxKnots { get; set; }

    public Boat(string registrationNumber, int wheelCount, VehicleColor color, double maxKnots) : base(
        registrationNumber, wheelCount, color)
    {
        MaxKnots = maxKnots;
    }
}