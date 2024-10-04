using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;

namespace GarageConsoleApp.Utils
{
    public static class Util
    {
        // Asks for a string input and allows skipping if allowNull is true.
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

        // Asks for an unsigned integer input and allows skipping if allowNull is true.
        public static uint? AskForUInt(string prompt, bool allowNull)
        {
            Console.Write($"{prompt}{(allowNull ? " (Optional - press Enter to skip)" : "")}: ");
            while (true)
            {
                string? input = Console.ReadLine();
                if (uint.TryParse(input, out uint result))
                {
                    return result;
                }

                if (string.IsNullOrWhiteSpace(input) && allowNull)
                {
                    return null;
                }

                Console.WriteLine($"Please enter a valid {prompt}");
            }
        }

        // Asks for a double input and allows skipping if allowNull is true.
        public static double? AskForDouble(string prompt, bool allowNull)
        {
            Console.Write($"{prompt}{(allowNull ? " (Optional - press Enter to skip)" : "")}: ");
            while (true)
            {
                string? input = Console.ReadLine();
                if (double.TryParse(input, out double result))
                {
                    return result;
                }

                if (string.IsNullOrWhiteSpace(input) && allowNull)
                {
                    return null;
                }

                Console.WriteLine($"Please enter a valid {prompt}");
            }
        }

        // Asks for a color input and allows skipping if allowNull is true.
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
                        // Check against known colors
                        Console.WriteLine("Please enter a valid color: ");
                    }
                }

                if (string.IsNullOrWhiteSpace(input) && allowNull)
                {
                    return null;
                }
            }
        }


        // Asks for a boolean input (yes/no) and allows skipping if allowNull is true.
        public static bool? AskForBool(string prompt, bool allowNull)
        {
            while (true)
            {
                Console.Write($"{prompt} (y/n){(allowNull ? " (Optional - press Enter to skip)" : "")}: ");
                string? input = Console.ReadLine()?.ToLower();

                if (input == "y")
                {
                    return true;
                }

                if (input == "n")
                {
                    return false;
                }

                if (string.IsNullOrWhiteSpace(input) && allowNull)
                {
                    return null;
                }

                Console.WriteLine("Invalid input. Please enter 'y' for yes or 'n' for no.");
            }
        }
    }
}