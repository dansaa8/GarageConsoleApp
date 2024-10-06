using System.Drawing;
using GarageConsoleApp.Entities;
using GarageConsoleApp.Entities.Garage;
using GarageConsoleApp.Entities.Vehicle;
using GarageConsoleApp.Handlers;
using GarageConsoleApp.Utils;

namespace GarageConsoleApp;

public class App
{
    private readonly List<Garage<Vehicle>> garages;
    private readonly MenuManager _menuManager;

    public App()
    {
        garages = new List<Garage<Vehicle>>();
        garages.Add(new Garage<Vehicle>(4));
        PopulateGarageWithInitialValues(garages[0]);
        _menuManager = new MenuManager();
    }

    public void Run()
    {
        bool appRunning = true;
        do
        {
            Console.Clear();
            ConsoleUtil.PrintMenu();
            GetCommand(ref appRunning);
        } while (appRunning);
    }

    public void GetCommand(ref bool runApp)
    {
        ConsoleKey keyPressed = ConsoleUtil.GetKey();

        switch (keyPressed)
        {
            case ConsoleKey.L:
                _menuManager.ListVehicles(garages[0]);
                break;
            case ConsoleKey.T:
            {
                _menuManager.ListVehicleTypes(garages[0]);
            }
                break;
            case ConsoleKey.A:
            {
                _menuManager.AddVehicle(garages[0]);
                break;
            }
            case ConsoleKey.D:
            {
                _menuManager.RemoveVehicle(garages[0]);
                break;
            }
            case ConsoleKey.S:
            {
                _menuManager.SearchVehicles(garages[0]);
                break;
            }
            case ConsoleKey.N:
            {
                Console.WriteLine("Creating new garage");
                garages[0] = new Garage<Vehicle>(InputHandler.GetGarageSize());
                Console.WriteLine("Garage was created");
                break;
            }
            case ConsoleKey.E:
            {
                runApp = false;
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