using GarageConsoleApp.Entities;
using GarageConsoleApp.Entities.Garage;

namespace GarageConsoleApp.Tests.Entities.Garage;

public class GarageTest
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
        Car car = new Car("abc123", 4, VehicleColor.Black, true);

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
        Car car1 = new Car("def456", 4, VehicleColor.Black, true);
        Car car2 = new Car("abc123", 4, VehicleColor.Black, true);


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
        Car car1 = new Car("def456", 4, VehicleColor.Black, true);
        Car car2 = new Car("abc123", 4, VehicleColor.Black, true);


        // Act
        Garage<Vehicle> garage = new Garage<Vehicle>(garageSize);
        garage.Add(car1);
        garage.Add(car2);
        Vehicle removedCar = garage.Remove(1); // car2 is removed, since it was added on index1


        // Assert
        Assert.Equal(car2, removedCar);
    }


    // [Fact]
    // public void GetAllVehicles_WhenCalled_ReturnsAllVehicles()
    // {
    //     // Arrange
    //     int garageSize = 8;
    //     Car car1 = new Car("def456", 4, VehicleColor.Black, true);
    //     Car car2 = new Car("def456", 4, VehicleColor.Black, true);
    //
    //     // Act
    //     Garage<Vehicle> garage = new Garage<Vehicle>(garageSize);
    //     garage.Add(car1);
    //     garage.Add(car2);
    //     var allVehicles = garage.GetAll();
    //
    //     // Assert
    //     Assert.Contains(car1, allVehicles);
    //     Assert.Contains(car2, allVehicles);
    //     Assert.Equal(2, allVehicles.Count());
    // }
}