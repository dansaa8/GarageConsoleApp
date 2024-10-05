namespace GarageConsoleApp.Utils
{
    public static class ConsoleUtil
    {
        public static void PrintMenu()
        {
            Console.WriteLine("Options: ");
            Console.WriteLine("L - List All Vehicles");
            Console.WriteLine("T - List Vehicle Types");
            Console.WriteLine("A - Add Vehicle");
            Console.WriteLine("D - Delete Vehicle");
            Console.WriteLine("S - Search Vehicle");
            Console.WriteLine("N - Create new garage");
            Console.WriteLine("E - Exit App");
        }

        public static void PrintRemoveMessage(string removedVehicle)
        {
            if (!string.IsNullOrWhiteSpace(removedVehicle))
            {
                Console.WriteLine($"{removedVehicle}\n was removed.");
            }
            else
            {
                Console.WriteLine("No vehicle was found to be removed.");
            }
        }
        public static void WaitForContinue()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        
        public static ConsoleKey GetKey() => Console.ReadKey(intercept: true).Key;
    }
}