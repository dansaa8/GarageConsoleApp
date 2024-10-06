using System.Drawing;
using GarageConsoleApp.Entities;
using GarageConsoleApp.Entities.Garage;
using GarageConsoleApp.Entities.Vehicle;
using GarageConsoleApp.Handlers;
using GarageConsoleApp.Services;

namespace GarageConsoleApp.Tests.Services.GarageHandler;

public class GarageHandler_ListAllTypesTests
{
    [Fact]
    public void ListAllVehicleTypes_WhenCalled_ReturnsStringWithAllVehicleTypesInOrder()
    {
        // Arrange
        Garage<Vehicle> garage = GarageHandlerTestUtils.CreateGarageWith3Vehicles();
        GarageHandler<Vehicle> garageHandler = new GarageHandler<Vehicle>();

        Boat boat = new Boat("jkl321", 2, Color.White, 5.5);
        garage.Add(boat); // Add one extra vehicle
        string expectedString = "Boats: 2" + "\nCars: 1" + "\nMotorcycles: 1";

        // Act
        string actualString = garageHandler.ListAllVehicleTypes(garage);

        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void ListAllVehicleTypes_WhenCalledWithOneTypeNotInGarage_ReturnsStringWithTwoTypes()
    {
        // Arrange
        Garage<Vehicle> garage = GarageHandlerTestUtils.CreateGarageWith3Vehicles();
        GarageHandler<Vehicle> garageHandler = new GarageHandler<Vehicle>();
        garageHandler.RemoveVehicle(garage, "abc123"); // car removed, only two types should be returned
        string expectedString = "Boats: 1" + "\nMotorcycles: 1";

        // Act
        string actualString = garageHandler.ListAllVehicleTypes(garage);

        // Assert
        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void ListAllVehicleTypes_WithEmptyGarage_ReturnsEmptyString()
    {
        // Arrange
        Garage<Vehicle> garage = new Garage<Vehicle>(8); // Empty garage
        GarageHandler<Vehicle> garageHandler = new GarageHandler<Vehicle>();

        // Act
        string actualString = garageHandler.ListAllVehicleTypes(garage);

        // Assert
        Assert.Empty(actualString);
    }
}