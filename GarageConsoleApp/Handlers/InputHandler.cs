using System.Drawing;
using GarageConsoleApp.Utils;
using GarageConsoleApp.Entities;

namespace GarageConsoleApp.Handlers
{
    public static class InputHandler
    {
        public static uint? GetWheelCount(bool allowNull)
        {
            Console.Clear();
            return ValueInputUtil.AskForUInt("Wheel count", allowNull);
        }

        public static bool? GetIsAutomatic(bool allowNull)
        {
            Console.Clear();
            return ValueInputUtil.AskForBool("Is automatic", allowNull);
        }

        public static double? GetMaxKnots(bool allowNull)
        {
            Console.Clear();
            return ValueInputUtil.AskForDouble("Max knots", allowNull);
        }

        public static double? GetMaxSpeed(bool allowNull)
        {
            Console.Clear();
            return ValueInputUtil.AskForDouble("Max speed", allowNull);
        }

        public static string? GetRegistrationNumber(bool allowNull)
        {
            Console.Clear();
            return ReferenceInputUtil.AskForString("Registration number", allowNull);
        }

        public static Color? GetColor(bool allowNull)
        {
            Console.Clear();
            return ReferenceInputUtil.AskForColor("Color", allowNull);
        }

        public static VehicleType? GetVehicleType(bool allowNull)
        {
            Console.Clear();
            return ReferenceInputUtil.AskForVehicleType(allowNull);
        }

        public static uint GetGarageSize()
        {
            Console.Clear();
            uint? GarageSize = ValueInputUtil.AskForUInt("Garage size", false);
            if (GarageSize.HasValue)
            {
                return GarageSize.Value;
            }

            throw new InvalidOperationException("Garage size is required.");
        }
    }
}