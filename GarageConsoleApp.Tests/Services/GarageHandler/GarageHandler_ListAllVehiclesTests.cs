using GarageConsoleApp.Entities;
using GarageConsoleApp.Entities.Garage;
using GarageConsoleApp.Services;
using System.Collections.Generic;
using GarageConsoleApp.Entities.Vehicle;
using GarageConsoleApp.Handlers; // Required for List

namespace GarageConsoleApp.Tests.Services.GarageHandler;

public class GarageHandler_ListAllVehiclesTests
{
    [Fact]
    public void ListAllVehicles_WhenCalled_ReturnsListWithAllVehicles()
    {
        // Arrange
        Garage<Vehicle> garage = GarageHandlerTestUtils.CreateGarageWith3Vehicles();
        GarageHandler<Vehicle> garageHandler = new GarageHandler<Vehicle>();
        List<string> expectedList = new List<string>
        {
            "Registration Number: abc123, Wheel Count: 4, Color: Black, Is Automatic: True",
            "Registration Number: def456, Wheel Count: 4, Color: Red, Max Knots: 20,5",
            "Registration Number: ghi789, Wheel Count: 2, Color: Yellow, Max Speed Per Kilometer: 255"
        };

        // Act
        List<string> actualList = garageHandler.ListAllVehicles(garage);

        // Assert
        Assert.Equal(expectedList, actualList);
    }

    [Fact]
    public void ListAllVehicles_WhenCalledWithEmptyGarage_ReturnsEmptyList()
    {
        // Arrange
        Garage<Vehicle> garage = new Garage<Vehicle>(8);  // Empty garage
        GarageHandler<Vehicle> garageHandler = new GarageHandler<Vehicle>();

        // Act
        List<string> actualList = garageHandler.ListAllVehicles(garage);

        // Assert
        Assert.Empty(actualList);  // Assert that the returned list is empty
    }
}