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
        Garage<Vehicle> garage = CreateGarageWith3TestVehicles();
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
        Garage<Vehicle> garage = CreateGarageWith3TestVehicles();
        GarageHandler<Vehicle> garageHandler = new GarageHandler<Vehicle>();

        // Act
        string actualString = garageHandler.RemoveVehicle(garage, "jkl321");

        // Assert
        Assert.Empty(actualString);
    }

    [Fact]
    public void ListAllVehiclesWithGarageHandler_WhenCalled_ReturnsStringWithAllVehicles()
    {
        // Arrange
        Garage<Vehicle> garage = CreateGarageWith3TestVehicles();
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

    [Fact]
    public void ListAllVehicleTypes_WhenCalled_ReturnsStringWithAllVehicleTypesInOrder()
    {
        // Arrange
        Garage<Vehicle> garage = CreateGarageWith3TestVehicles();
        GarageHandler<Vehicle> garageHandler = new GarageHandler<Vehicle>();

        Boat boat = new Boat("jkl321", 2, VehicleColor.White, 5.5);
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
        Garage<Vehicle> garage = CreateGarageWith3TestVehicles();
        GarageHandler<Vehicle> garageHandler = new GarageHandler<Vehicle>();
        garageHandler.RemoveVehicle(garage, "abc123"); // car removed, only two types should be returned
        string expectedString = "Boats: 1" + "\nMotorcycles: 1";

        // Act
        string actualString = garageHandler.ListAllVehicleTypes(garage);

        // Assert
        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void ListAllVehicleTypes_WhenCalledWithNonExistingVehicle_ReturnsEmptyString()
    {
        // Arrange
        Garage<Vehicle> garage = new Garage<Vehicle>(8); // Empty garage
        GarageHandler<Vehicle> garageHandler = new GarageHandler<Vehicle>();

        // Act
        string actualString = garageHandler.ListAllVehicleTypes(garage);

        // Assert
        Assert.Empty(actualString);
    }

    private Garage<Vehicle> CreateGarageWith3TestVehicles()
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