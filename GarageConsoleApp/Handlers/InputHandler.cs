using System;
using System.Drawing;
using GarageConsoleApp.Utils;
using GarageConsoleApp.Entities;

namespace GarageConsoleApp.Handlers
{
    public static class InputHandler
    {
        public static VehicleType? GetVehicleType(bool allowNull)
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
                Console.Write("\nPlease type your choice: ");
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

                Console.WriteLine("Invalid vehicle type. Please try again.");
            }
        }

        public static string? GetRegistrationNumber(bool allowNull)
        {
            Console.Clear();
            return InputUtil.AskForString("Registration number", allowNull);
        }

        public static uint? GetWheelCount(bool allowNull)
        {
            Console.Clear();
            return InputUtil.AskForUInt("Wheel count", allowNull);
        }

        public static Color? GetColor(bool allowNull)
        {
            Console.Clear();
            return InputUtil.AskForColor("Color", allowNull);
        }

        public static bool? GetIsAutomatic(bool allowNull)
        {
            Console.Clear();
            return InputUtil.AskForBool("Is automatic", allowNull);
        }

        public static double? GetMaxKnots(bool allowNull)
        {
            Console.Clear();
            return InputUtil.AskForDouble("Max knots", allowNull);
        }

        public static double? GetMaxSpeed(bool allowNull)
        {
            Console.Clear();
            return InputUtil.AskForDouble("Max speed", allowNull);
        }
    }
}