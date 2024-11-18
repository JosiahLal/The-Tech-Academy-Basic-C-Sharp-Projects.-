using System;

namespace InterfaceExample
{
    // Step 1: Create an interface called IQuittable
    // The interface defines a method 'Quit' which doesn't return anything (void)
    public interface IQuittable
    {
        void Quit();  // Declare the Quit method
    }

    // Step 2: Create the Employee class which inherits from IQuittable
    // The Employee class must implement the Quit method since it is part of the IQuittable interface
    public class Employee : IQuittable
    {
        public string Name { get; set; } // Property to store employee name

        // Step 2.1: Implement the Quit method from the IQuittable interface
        public void Quit()
        {
            // Print a message when the employee quits
            Console.WriteLine($"{Name} has quit the job.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Step 3: Use polymorphism to create an object of type IQuittable
            // Polymorphism allows you to use the interface type as the variable type
            IQuittable quitter = new Employee { Name = "John Doe" };

            // Step 3.1: Call the Quit method on the IQuittable object
            // Since 'quitter' is of type IQuittable, we can call Quit() on it, which will refer to the method from Employee class
            quitter.Quit();  // This will print: "John Doe has quit the job."

            // Add a message to indicate the end of the program
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(); // Keep the console window open until the user presses a key
        }
    }
}
