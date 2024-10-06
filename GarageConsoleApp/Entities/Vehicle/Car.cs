using System.Drawing;

namespace GarageConsoleApp.Entities.Vehicle;

public class Car : Vehicle
{
    public bool IsAutomatic { get; }

    public Car(string registrationNumber, uint wheelCount, Color color, bool isAutomatic) : base(
        registrationNumber, wheelCount, color)
    {
        IsAutomatic = isAutomatic;
    }

    public override object Clone()
    {
        return MemberwiseClone();
    }

    public override string ToString()
    {
        return base.ToString() + $", Is Automatic: {IsAutomatic}";
    }
}