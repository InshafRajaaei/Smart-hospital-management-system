using System;

namespace HospitalManagementSystem
{
    static class Utility
    {
        public static int GetIntInput(string message)
        {
            int input;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.Write("Invalid input. Please enter a valid number: ");
            }
            return input;
        }
        public static decimal GetDecimalInput(string message)
        {
            decimal input;
            Console.Write(message);
            while (!decimal.TryParse(Console.ReadLine(), out input))
            {
                Console.Write("Invalid input. Please enter a valid decimal: ");
            }
            return input;
        }
        public static string GetNonEmptyString(string message)
        {
            string? input;
            do
            {
                Console.Write(message);
                input = Console.ReadLine()?.Trim();
            } while (string.IsNullOrWhiteSpace(input));
            return input;
        }
    }
}