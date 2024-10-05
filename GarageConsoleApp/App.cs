using System.Drawing;
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
    private readonly MenuHandler menuHandler;

    public App()
    {
        ui = new ConsoleUI();
        garages = new List<Garage<Vehicle>>();
        garages.Add(new Garage<Vehicle>(4));
        PopulateGarageWithInitialValues(garages[0]);
        menuHandler = new MenuHandler();
    }

    public void Run()
    {
        bool appRunning = true;
        do
        {
            Console.Clear();
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
                menuHandler.ListVehicles(garages[0]);
                break;
            case ConsoleKey.T:
            {
                menuHandler.ListVehicleTypes(garages[0]);
            }
                break;
            case ConsoleKey.A:
            {
                menuHandler.AddVehicle(garages[0]);
                break;
            }
            case ConsoleKey.D:
            {
                menuHandler.RemoveVehicle(garages[0]);
                break;
            }
            case ConsoleKey.S:
            {
                menuHandler.SearchVehicles(garages[0]);
                break;
            }
        }
    }

    private void PopulateGarageWithInitialValues(Garage<Vehicle> garage)
    {
        garage.Add(new Boat("boat1", 0, Color.Pink, 25.3));
        garage.Add(new Boat("boat2", 0, Color.Yellow, 25.3));
        garage.Add(new Car("car1", 4, Color.Pink, false));
        garage.Add(new Motorcycle("Motorcycle1", 2, Color.Pink, 250));
    }
}