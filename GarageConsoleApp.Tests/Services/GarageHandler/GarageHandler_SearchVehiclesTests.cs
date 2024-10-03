using System.Drawing;
using GarageConsoleApp.Entities;
using GarageConsoleApp.Entities.Garage;
using GarageConsoleApp.Services;

namespace GarageConsoleApp.Tests.Services.GarageHandler;

public class GarageHandler_SearchVehiclesTests
{
    [Fact]
    public void SearchForVehicles_WithSearchCriteriaYellow_ShouldReturnAllYellowVehicles()
    {
        // Arrange
        Garage<Vehicle> garage = GarageHandlerTestUtils.CreateGarageWith9Vehicles();
        GarageHandler<Vehicle> garageHandler = new GarageHandler<Vehicle>();

        SearchOptions searchOptions = new SearchOptions();
        searchOptions.Color = Color.Yellow;
        string expectedBoat = "Registration Number: boat123, Wheel Count: 0, Color: Yellow, Max Knots: 20,5";
        string expectedMc = "Registration Number: mc123, Wheel Count: 2, Color: Yellow, Max Speed Per Kilometer: 170";
        string expectedCar = "Registration Number: car123, Wheel Count: 4, Color: Yellow, Is Automatic: False";

        // Act
        List<string> returnedVehicles = garageHandler.SearchVehicles(garage, searchOptions);

        // Assert
        Assert.Contains(expectedBoat, returnedVehicles);
        Assert.Contains(expectedMc, returnedVehicles);
        Assert.Contains(expectedCar, returnedVehicles);

        Assert.Equal(3, returnedVehicles.Count);
    }
}