using GarageConsoleApp.Entities;
using GarageConsoleApp.Entities.Garage;
using GarageConsoleApp.Services;

namespace GarageConsoleApp.Tests.Services.GarageHandler;

public class GarageHandler_RemoveVehicleTests
{
    [Fact]
    public void RemoveVehicleWithGarageHandler_WhenCalled_ReturnsVehicleFromGarage()
    {
        // Arrange
        Garage<Vehicle> garage = GarageHandlerUtils.CreateGarageWith3Vehicles();
        GarageHandler<Vehicle> garageHandler = new GarageHandler<Vehicle>();

        Boat boat = new Boat("jkl321", 2, VehicleColor.White, 5.5);
        garage.Add(boat);
        string expectedString = "Registration Number: jkl321, Wheel Count: 2, Color: White, Max Knots: 5,5";

        // Act
        string actualString = garageHandler.RemoveVehicle(garage, "jkl321");

        // Assert
        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void RemoveVehicleWithGarageHandler_WhenCalledWithNonExistingVehicle_ReturnsEmptyString()
    {
        // Arrange
        Garage<Vehicle> garage = GarageHandlerUtils.CreateGarageWith3Vehicles();
        GarageHandler<Vehicle> garageHandler = new GarageHandler<Vehicle>();

        // Act
        string actualString = garageHandler.RemoveVehicle(garage, "jkl321");

        // Assert
        Assert.Empty(actualString);
    }
}