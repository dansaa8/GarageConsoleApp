using System.Drawing;
using GarageConsoleApp.Entities;
using GarageConsoleApp.Entities.Garage;

namespace GarageConsoleApp.Tests.Entities.Garage;

public class Garage_Tests
{
    [Fact]
    public void Constructor_GivenGarageSize_ReturnsNonNullGarage()
    {
        // Arrange
        int garageSize = 8;

        // Act
        Garage<Vehicle> garage = new Garage<Vehicle>(garageSize);

        // Assert
        Assert.NotNull(garage);
    }

    [Fact]
    public void AddVehicle_WhenCalled_ReturnsTrue()
    {
        // Arrange
        int garageSize = 8;
        Car car = new Car("abc123", 4, Color.Black, true);

        // Act
        Garage<Vehicle> garage = new Garage<Vehicle>(garageSize);
        bool vehicleIsAdded = garage.Add(car);

        // Assert
        Assert.True(vehicleIsAdded);
    }

    [Fact]
    public void AddVehicle_WhenGarageIsFull_ReturnsFalse()
    {
        // Arrange
        int garageSize = 1;
        Car car1 = new Car("abc123", 4, Color.Black, true);
        Car car2 = new Car("def456", 4, Color.Black, true);


        // Act
        Garage<Vehicle> garage = new Garage<Vehicle>(garageSize);
        bool car1IsAdded = garage.Add(car1);
        bool car2IsAdded = garage.Add(car2);


        // Assert
        Assert.True(car1IsAdded);
        Assert.False(car2IsAdded);
    }

    [Fact]
    public void RemoveVehicle_WhenCalled_ReturnsRemovedVehicle()
    {
        // Arrange
        int garageSize = 2;
        Car car1 = new Car("abc123", 4, Color.Black, true);
        Car car2 = new Car("def456", 4, Color.Black, true);


        // Act
        Garage<Vehicle> garage = new Garage<Vehicle>(garageSize);
        garage.Add(car1);
        garage.Add(car2);
        Vehicle? removedCar = garage.RemoveByRegNumber("def456"); // car2 is removed, since it was added on index1

        // Assert
        Assert.Equal(car2, removedCar);
    }

    [Fact]
    public void ForeachVehicle_WhenCalled_ReturnsAllVehicles()
    {
        // Arrange
        int garageSize = 3;
        Car car = new Car("abc123", 4, Color.Black, true);
        Boat boat = new Boat("def456", 0, Color.Red, 20.5);
        Motorcycle mc = new Motorcycle("ghi789", 2, Color.Yellow, 255);

        // Act
        Garage<Vehicle> garage = new Garage<Vehicle>(garageSize);
        garage.Add(car);
        garage.Add(boat);
        garage.Add(mc);
        garage.RemoveByRegNumber("abc123"); // the car should not be in foreach

        string expectedBoatString =
            "Registration Number: def456, Wheel Count: 0, Color: Red, Max Knots: 20,5";
        string expectedMcString =
            "Registration Number: ghi789, Wheel Count: 2, Color: Yellow, Max Speed Per Kilometer: 255";

        List<string> expectedStrings = new List<string> { expectedBoatString, expectedMcString };
        List<string> returnedValsFromIEnumerator = new List<string>();

        foreach (Vehicle vehicle in garage)
        {
            returnedValsFromIEnumerator.Add(vehicle.ToString());
        }

        // Assert
        Assert.Equal(expectedStrings, returnedValsFromIEnumerator);
    }
}