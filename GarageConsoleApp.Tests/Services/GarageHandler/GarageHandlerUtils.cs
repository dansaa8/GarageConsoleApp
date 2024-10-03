using GarageConsoleApp.Entities;
using GarageConsoleApp.Entities.Garage;

namespace GarageConsoleApp.Tests.Services.GarageHandler;

public static class GarageHandlerUtils
{
    public static Garage<Vehicle> CreateGarageWith3Vehicles()
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

    public static Garage<Vehicle> CreateGarageWith9Vehicles()
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