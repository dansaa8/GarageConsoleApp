namespace GarageConsoleApp.Entities;

public class Boat : Vehicle
{
    public double MaxKnots { get; }

    public Boat(string registrationNumber, int wheelCount, VehicleColor color, double maxKnots) : base(
        registrationNumber, wheelCount, color)
    {
        MaxKnots = maxKnots;
    }

    public override object Clone()
    {
        return MemberwiseClone();
    }

    public override string ToString()
    {
        return base.ToString() + $", Max Knots: {MaxKnots}";
    }
}