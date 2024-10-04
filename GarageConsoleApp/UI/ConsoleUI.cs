namespace GarageConsoleApp.UI;

public class ConsoleUI
{
    public const string ListAll = "L";
    public const string ListTypes = "T";
    public const string Add = "A";
    public const string Delete = "D";
    public const string Search = "S";
    public const string Exit = "E";

    public void PrintMenu()
    {
        Console.WriteLine("Options: ");
        Console.WriteLine($"{ListAll} - List All Vehicles"); // Add option for listing all vehicles
        Console.WriteLine($"{ListTypes} - List Vehicle Types");
        Console.WriteLine($"{Add} - Add Vehicle");
        Console.WriteLine($"{Delete} - Delete Vehicle");
        Console.WriteLine($"{Search} - Search Vehicle");
        Console.WriteLine($"{Exit} - Exit App");
    }

    public void PrintRemoveMessage(string removedVehicle)
    {
        if (!String.IsNullOrWhiteSpace(removedVehicle))
        {
            Console.WriteLine($"{removedVehicle}\n was removed.");
        }
        else
        {
            Console.WriteLine("No vehicle was found to be removed.");
        }
    }

    public ConsoleKey GetKey() => Console.ReadKey(intercept: true).Key;
}