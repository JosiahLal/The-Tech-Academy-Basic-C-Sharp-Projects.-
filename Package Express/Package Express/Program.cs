using System;

namespace PackageExpress
{
    class Program
    {
        static void Main(string[] args)
        {
            // Welcome message to the user
            Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

            // Prompt the user for the package weight
            Console.Write("Please enter the package weight: ");
            double weight = Convert.ToDouble(Console.ReadLine());

            // Check if the weight exceeds the maximum allowed weight
            if (weight > 50)
            {
                // Display error message and exit if the package is too heavy
                Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
                return; // Exit the program
            }

            // Prompt the user for the package width
            Console.Write("Please enter the package width: ");
            double width = Convert.ToDouble(Console.ReadLine());

            // Prompt the user for the package height
            Console.Write("Please enter the package height: ");
            double height = Convert.ToDouble(Console.ReadLine());

            // Prompt the user for the package length
            Console.Write("Please enter the package length: ");
            double length = Convert.ToDouble(Console.ReadLine());

            // Check if the total dimensions exceed the maximum allowed size
            if (width + height + length > 50)
            {
                // Display error message and exit if the package is too big
                Console.WriteLine("Package too big to be shipped via Package Express.");
                return; // Exit the program
            }

            // Calculate the shipping quote
            // Multiply the dimensions together and then by the weight
            double quote = (width * height * length * weight) / 100;

            // Display the estimated shipping quote to the user
            Console.WriteLine($"Your estimated total for shipping this package is: ${quote:F2}");

            // Thank the user for using the service
            Console.WriteLine("Thank you!");
        }
    }
}
