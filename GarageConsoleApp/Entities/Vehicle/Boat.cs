using System.Drawing;

namespace GarageConsoleApp.Entities.Vehicle;

public class Boat : Vehicle
{
    public double MaxKnots { get; }

    public Boat(string registrationNumber, uint wheelCount, Color color, double maxKnots) : base(
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