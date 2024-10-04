using GarageConsoleApp.Entities;
using GarageConsoleApp.Entities.Garage;
using GarageConsoleApp.Handlers;
using GarageConsoleApp.Services;
using GarageConsoleApp.UI;

namespace GarageConsoleApp;

public class App
{
    private readonly ConsoleUI ui;
    private readonly List<Garage<Vehicle>> garages;
    private readonly GarageHandler<Vehicle> garageHandler;

    public App()
    {
        ui = new ConsoleUI();
        garages = new List<Garage<Vehicle>>();
        garages.Add(new Garage<Vehicle>(6));
        garageHandler = new GarageHandler<Vehicle>();
    }

    public void Run()
    {
        bool appRunning = true;
        do
        {
            ui.PrintMenu();
            GetCommand();
        } while (appRunning);
    }

    public void GetCommand()
    {
        ConsoleKey keyPressed = ui.GetKey();

        switch (keyPressed)
        {
            case ConsoleKey.L:
            {
                List<string> allVehicles = garageHandler.ListAllVehicles(garages[0]);
                foreach (var vehicle in allVehicles)
                {
                    Console.WriteLine(vehicle);
                }
                break;
            }
            case ConsoleKey.T:
            {
                string allTypes = garageHandler.ListAllVehicleTypes(garages[0]);
                Console.WriteLine(allTypes);
                break;
            }
            case ConsoleKey.A:
                garageHandler.AddVehicle(garages[0], VehicleFactory.CreateVehicle());
                break;
            case ConsoleKey.D:
                garageHandler.RemoveVehicle(garages[0],
                    InputHandler.GetRegistrationNumber(false));
                break;
            case ConsoleKey.S:
                garageHandler.SearchVehicles(garages[0], SearchFactory.CreateVehicleSearch());
                break;
        }
    }
}