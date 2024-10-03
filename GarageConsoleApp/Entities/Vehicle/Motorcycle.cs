using System.Drawing;

namespace GarageConsoleApp.Entities;

public class Motorcycle : Vehicle
{
    public double MaxSpeedKmPerHour { get; }

    public Motorcycle(string registrationNumber, uint wheelCount, Color color, double maxSpeedKmPerHour) : base(
        registrationNumber, wheelCount, color)
    {
        MaxSpeedKmPerHour = maxSpeedKmPerHour;
    }

    public override object Clone()
    {
        return MemberwiseClone();
    }

    public override string ToString()
    {
        return base.ToString() + $", Max Speed Per Kilometer: {MaxSpeedKmPerHour}";
    }
}