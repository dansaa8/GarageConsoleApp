namespace GarageConsoleApp.Entities;

public class Car : Vehicle
{
    public bool IsAutomatic { get; set; }

    public Car(string registrationNumber, int wheelCount, VehicleColor color, bool isAutomatic) : base(
        registrationNumber, wheelCount, color)
    {
        IsAutomatic = isAutomatic;
    }
}