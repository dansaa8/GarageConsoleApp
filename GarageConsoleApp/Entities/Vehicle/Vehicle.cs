namespace GarageConsoleApp.Entities;

public abstract class Vehicle : ICloneable
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

    public abstract object Clone();

    public override string ToString()
    {
        return $"Registration number: {RegistrationNumber}, Wheel Count: {WheelCount}  Color: {Color}";
    }
}