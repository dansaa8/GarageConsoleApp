using System.Drawing;

namespace GarageConsoleApp.Entities;

public abstract class Vehicle : ICloneable
{
    public string RegistrationNumber { get; }
    public uint WheelCount { get; }
    public Color Color { get; }

    protected Vehicle(string registrationNumber, uint wheelCount, Color color)
    {
        RegistrationNumber = registrationNumber;
        WheelCount = wheelCount;
        Color = color;
    }

    public abstract object Clone();

    public override string ToString()
    {
        return $"Registration Number: {RegistrationNumber}, Wheel Count: {WheelCount}, Color: {Color.Name}";
    }
}