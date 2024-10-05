using GarageConsoleApp.Entities;
using GarageConsoleApp.Entities.Garage;
using GarageConsoleApp.Services;
using GarageConsoleApp.Utils;

namespace GarageConsoleApp.Handlers;

public class MenuManager
{
    private readonly VehicleFactory vehicleFactory;
    private readonly GarageHandler<Vehicle> garageHandler;


    public MenuManager()
    {
        vehicleFactory = new VehicleFactory();
        garageHandler = new GarageHandler<Vehicle>();
    }

    public void ListVehicles(Garage<Vehicle> garage)
    {
        Console.Clear();
        List<string> allVehicles = garageHandler.ListAllVehicles(garage);
        if (allVehicles.Count == 0) Console.WriteLine("No vehicles found");
        else
        {
            Console.WriteLine("<Vehicles List>");
            allVehicles.ForEach(Console.WriteLine);
        }

        ConsoleUtil.WaitForContinue();
    }

    public void ListVehicleTypes(Garage<Vehicle> garage)
    {
        Console.Clear();
        string allTypes = garageHandler.ListAllVehicleTypes(garage);
        if (string.IsNullOrWhiteSpace(allTypes)) Console.WriteLine("No vehicle types found");
        else
        {
            Console.WriteLine("<Vehicle Types>");
            Console.WriteLine(allTypes);
        }

        ConsoleUtil.WaitForContinue();
    }

    public void AddVehicle(Garage<Vehicle> garage)
    {
        Console.Clear();
        Console.WriteLine("<Adding new vehicle>");
        bool garageIsFull = garageHandler.IsGarageFull(garage);
        if (garageIsFull)
        {
            Console.WriteLine("Garage is full!\n");
        }
        else
        {
            bool isAdded = garageHandler.AddVehicle(garage, vehicleFactory.CreateVehicle());
            if (isAdded)
            {
                Console.Clear();
                Console.WriteLine("Vehicle was added!\n");
            }
            else
            {
                Console.WriteLine("Something went wrong. Vehicle was not added!\n");
            }
        }

        ConsoleUtil.WaitForContinue();
    }

    public void RemoveVehicle(Garage<Vehicle> garage)
    {
        string removedVehicle = garageHandler.RemoveVehicle(garage,
            InputHandler.GetRegistrationNumber(false));
        if (!string.IsNullOrWhiteSpace(removedVehicle))
        {
            Console.Clear();
            Console.WriteLine($"Following vehicle was removed:\n{removedVehicle}");
        }
        else
        {
            Console.WriteLine("No vehicle was removed.");
        }

        ConsoleUtil.WaitForContinue();
    }

    public void SearchVehicles(Garage<Vehicle> garage)
    {
        List<string> foundVehicles = garageHandler.SearchVehicles(garage, SearchFactory.CreateVehicleSearch());
        if (!foundVehicles.Any()) Console.WriteLine("No vehicles found with given search criteria");
        else
        {
            Console.WriteLine("<Matched Vehicles>");
            foundVehicles.ForEach(Console.WriteLine);
        }

        ConsoleUtil.WaitForContinue();
    }

    public void CreateNewGarage(List<Garage<Vehicle>> garageList)
    {
        Console.WriteLine("Creating new garage");
        Garage<Vehicle> newGarage = new Garage<Vehicle>(InputHandler.GetGarageSize());
        garageList[0] = newGarage;
        Console.WriteLine("Garage was created");
        ConsoleUtil.WaitForContinue();
    }
}