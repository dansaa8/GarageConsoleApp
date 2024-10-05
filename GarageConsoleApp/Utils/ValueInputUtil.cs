namespace GarageConsoleApp.Utils
{
    public static class ValueInputUtil
    {
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

                Console.Write($"Please enter a valid {prompt}: ");
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