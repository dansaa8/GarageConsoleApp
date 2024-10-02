using GarageConsoleApp.Entities;
using GarageConsoleApp.Entities.Garage;
using GarageConsoleApp.Services;

namespace GarageConsoleApp.Tests.Services.GarageHandler.Tests;

public class SearchForVehicles
{
    [Fact]
    public void SearchForVehicles_WithSearchCriteriaYellow_ShouldReturnAllYellowVehicles()
    {
        // Arrange
        Garage<Vehicle> garage = CreateGarageWith9Vehicles();
        GarageHandler<Vehicle> garageHandler = new GarageHandler<Vehicle>();

        SearchOptions searchOptions = new SearchOptions();
        searchOptions.Color = VehicleColor.Yellow;
        string expectedBoat = "Registration Number: boat123, Wheel Count: 0, Color: Yellow, Max Knots: 20,5";
        string expectedMc = "Registration Number: mc123, Wheel Count: 2, Color: Yellow, Max Speed Per Kilometer: 170";
        string expectedCar = "Registration Number: car123, Wheel Count: 4, Color: Yellow, Is Automatic: False";

        // Act
        List<string> returnedVehicles = garageHandler.SearchForVehicles(garage, searchOptions);

        // Assert
        Assert.Contains(expectedBoat, returnedVehicles);
        Assert.Contains(expectedMc, returnedVehicles);
        Assert.Contains(expectedCar, returnedVehicles);
        
        Assert.Equal(3, returnedVehicles.Count);
    }

    private static Garage<Vehicle> CreateGarageWith9Vehicles()
    {
        Garage<Vehicle> garage = new Garage<Vehicle>(9);


        Boat yellowBoat = new Boat("boat123", 0, VehicleColor.Yellow, 20.5);
        Boat blueBoat = new Boat("boat456", 0, VehicleColor.Blue, 5.5);
        Boat whiteBoat = new Boat("boat789", 0, VehicleColor.White, 12);

        Motorcycle yellowMc = new Motorcycle("mc123",
            2, VehicleColor.Yellow, 170);
        Motorcycle silverMc = new Motorcycle("mc456",
            3, VehicleColor.Silver, 250);
        Motorcycle blackMc = new Motorcycle("mc789",
            2, VehicleColor.Black, 150);

        Car yellowCar1 = new Car("car123", 4, VehicleColor.Yellow, false);
        Car greenCar1 = new Car("car456", 4, VehicleColor.Green, false);
        Car redCar1 = new Car("car789", 6, VehicleColor.Red, false);

        garage.Add(yellowBoat);
        garage.Add(blueBoat);
        garage.Add(whiteBoat);

        garage.Add(yellowMc);
        garage.Add(silverMc);
        garage.Add(blackMc);

        garage.Add(yellowCar1);
        garage.Add(greenCar1);
        garage.Add(redCar1);

        return garage;
    }
}