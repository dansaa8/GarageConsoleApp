using GarageConsoleApp.Entities;
using GarageConsoleApp.Entities.Garage;
using GarageConsoleApp.Services;

namespace GarageConsoleApp.Tests.Services;

public class GarageHandlerTests
{
    [Fact]
    public void RemoveVehicleWithGarageHandler_WhenCalled_ReturnsVehicleFromGarage()
    {
        // Arrange
        Garage<Vehicle> garage = createGarageWith3TestVehicles();
        GarageHandler<Vehicle> garageHandler = new GarageHandler<Vehicle>();

        Boat boat = new Boat("jkl321", 2, VehicleColor.White, 5.5);
        garage.Add(boat);
        string expectedString = "Registration Number: jkl321, Wheel Count: 2, Color: White, Max Knots: 5,5";

        // Act
        string actualString = garageHandler.RemoveVehicle(garage, "jkl321");

        // Assert
        Assert.Equal(expectedString, actualString);
    }

    private Garage<Vehicle> createGarageWith3TestVehicles()
    {
        int garageSize = 8;
        Car car = new Car("abc123", 4, VehicleColor.Black, true);
        Boat boat = new Boat("def456", 4, VehicleColor.Red, 20.5);
        Motorcycle mc = new Motorcycle("ghi789", 2, VehicleColor.Yellow, 255);

        Garage<Vehicle> garage = new Garage<Vehicle>(garageSize);
        garage.Add(car);
        garage.Add(boat);
        garage.Add(mc);
        return garage;
    }
}