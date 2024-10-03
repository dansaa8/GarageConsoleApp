using GarageConsoleApp.Entities;
using GarageConsoleApp.Entities.Garage;
using GarageConsoleApp.Services;

namespace GarageConsoleApp.Tests.Services.GarageHandler;

public class GarageHandler_ListAllVehiclesTests
{
    [Fact]
    public void ListAllVehiclesWithGarageHandler_WhenCalled_ReturnsStringWithAllVehicles()
    {
        // Arrange
        Garage<Vehicle> garage = GarageHandlerUtils.CreateGarageWith3Vehicles();
        GarageHandler<Vehicle> garageHandler = new GarageHandler<Vehicle>();
        string expectedString =
            "Registration Number: abc123, Wheel Count: 4, Color: Black, Is Automatic: True" +
            "\nRegistration Number: def456, Wheel Count: 4, Color: Red, Max Knots: 20,5" +
            "\nRegistration Number: ghi789, Wheel Count: 2, Color: Yellow, Max Speed Per Kilometer: 255";

        // Act
        string actualString = garageHandler.ListAllVehicles(garage);

        // Assert
        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void ListAllVehiclesWithGarageHandler_WhenCalledWithNonExistingVehicle_ReturnsEmptyString()
    {
        // Arrange
        Garage<Vehicle> garage = new Garage<Vehicle>(8); // empty
        GarageHandler<Vehicle> garageHandler = new GarageHandler<Vehicle>();

        // Act
        string actualString = garageHandler.ListAllVehicles(garage);

        // Assert
        Assert.Empty(actualString);
    }
}