using System.ComponentModel;
using System.Drawing;
using GarageConsoleApp.Entities;
using GarageConsoleApp.Entities.Vehicle;

namespace GarageConsoleApp.Utils
{
    public static class ReferenceInputUtil
    {
        public static string? AskForString(string prompt, bool allowNull)
        {
            Console.Write($"{prompt}{(allowNull ? " (Optional - press Enter to skip)" : "")}: ");
            while (true)
            {
                string? input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) || allowNull)
                {
                    return string.IsNullOrWhiteSpace(input) ? null : input;
                }

                Console.WriteLine($"Please enter a valid {prompt}");
            }
        }

        public static Color? AskForColor(string prompt, bool allowNull)
        {
            Console.Write($"{prompt}{(allowNull ? " (Optional - press Enter to skip)" : "")}: ");
            while (true)
            {
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    try
                    {
                        Color color = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(input);
                        return color;
                    }
                    catch
                    {
                        Console.Write("Please enter a valid color: ");
                    }
                }

                if (string.IsNullOrWhiteSpace(input) && allowNull)
                {
                    return null;
                }
            }
        }

        public static VehicleType? AskForVehicleType(bool allowNull)
        {
            Console.Clear();
            Console.WriteLine("Enter vehicle type (options below):");

            // Print out each type defined in the VehicleType enum in a structured format.
            foreach (VehicleType type in Enum.GetValues(typeof(VehicleType)))
            {
                Console.WriteLine($"- {type}");
            }

            while (true)
            {
                Console.Write("Your choice: ");
                string? input = Console.ReadLine();

                // Try to parse the input to one of the available types in the enum VehicleType.
                if (Enum.TryParse<VehicleType>(input, true, out VehicleType result))
                {
                    return result;
                }

                // Check for null input if allowed
                if (string.IsNullOrWhiteSpace(input) && allowNull)
                {
                    return null;
                }

                Console.WriteLine("Invalid vehicle type. Choose one from the listed options.");
            }
        }
    }
}