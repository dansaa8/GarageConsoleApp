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
}