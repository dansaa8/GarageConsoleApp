using System;
using System.Drawing;
using GarageConsoleApp.Utils;
using GarageConsoleApp.Entities;

namespace GarageConsoleApp.Handlers
{
    public static class InputHandler
    {
        // Get the vehicle type, allowing null if allowNull is true.
        public static VehicleType? GetVehicleType(bool allowNull)
        {
            Console.WriteLine("Enter vehicle type: ");
            foreach (VehicleType type in Enum.GetValues(typeof(VehicleType)))
            {
                Console.WriteLine(type.ToString());
            }

            while (true)
            {
                string? input = Console.ReadLine();
                if (Enum.TryParse<VehicleType>(input, true, out VehicleType result))
                {
                    return result;
                }

                if (string.IsNullOrWhiteSpace(input) && allowNull)
                {
                    return null;
                }

                Console.WriteLine("Invalid vehicle type. Please try again.");
            }
        }

        public static string? GetRegistrationNumber(bool allowNull)
        {
            return Util.AskForString("Registration number", allowNull);
        }

        public static uint? GetWheelCount(bool allowNull)
        {
            return Util.AskForUInt("Wheel count", allowNull);
        }

        public static Color? GetColor(bool allowNull)
        {
            return Util.AskForColor("Color", allowNull);
        }

        public static bool? GetIsAutomatic(bool allowNull)
        {
            return Util.AskForBool("Is automatic", allowNull);
        }

        public static double? GetMaxKnots(bool allowNull)
        {
            return Util.AskForDouble("Max knots", allowNull);
        }

        public static double? GetMaxSpeed(bool allowNull)
        {
            return Util.AskForDouble("Max speed", allowNull);
        }
    }
}