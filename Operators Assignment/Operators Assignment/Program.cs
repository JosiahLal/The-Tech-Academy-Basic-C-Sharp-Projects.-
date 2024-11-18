using System;

namespace EmployeeComparisonApp
{
    // Step 1: Create the Employee class
    // This class contains properties for Id, FirstName, and LastName.
    public class Employee
    {
        // Properties to hold the employee's ID, First Name, and Last Name
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Step 2: Overload the '==' operator to compare Employee objects by their Id.
        // The method checks if the Id of two Employee objects is the same.
        public static bool operator ==(Employee e1, Employee e2)
        {
            // If both objects are the same reference, they are equal (including the case where both are null).
            if (ReferenceEquals(e1, e2))
            {
                return true;
            }

            // If either object is null, they cannot be equal.
            if (e1 is null || e2 is null)
            {
                return false;
            }

            // Compare the Id property of both employees
            return e1.Id == e2.Id;
        }

        // Step 3: Overload the '!=' operator to check for inequality.
        // This method returns the opposite of the '==' operator.
        public static bool operator !=(Employee e1, Employee e2)
        {
            // Negation of the '==' operator
            return !(e1 == e2);
        }

        // Override the Equals method to ensure correct comparison logic when using Equals() method.
        // It compares the Id property of two Employee objects.
        public override bool Equals(object obj)
        {
            // Ensure the object is an Employee, then compare their Id properties.
            if (obj is Employee otherEmployee)
            {
                return this.Id == otherEmployee.Id;
            }
            return false;
        }

        // Override the GetHashCode method to ensure consistency with the Equals method.
        // This is important when using collections that rely on hashing.
        public override int GetHashCode()
        {
            // Return the hash code of the Id property for consistent hashing
            return Id.GetHashCode();
        }
    }

    // Step 4: Program class with the Main method to test the Employee class and overloaded operators.
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate two Employee objects and assign values to their properties.
            Employee employee1 = new Employee { Id = 1, FirstName = "John", LastName = "Doe" };
            Employee employee2 = new Employee { Id = 1, FirstName = "Jane", LastName = "Smith" };

            // Compare the two Employee objects using the overloaded '==' operator.
            // The two employees have the same Id, so they should be considered equal.
            if (employee1 == employee2)
            {
                Console.WriteLine("The two employees are equal (based on Id).");
            }
            else
            {
                Console.WriteLine("The two employees are not equal (based on Id).");
            }

            // Compare the two Employee objects using the overloaded '!=' operator.
            // Since their Ids are the same, the result will be false (they are not unequal).
            if (employee1 != employee2)
            {
                Console.WriteLine("The two employees are not equal (based on Id).");
            }
            else
            {
                Console.WriteLine("The two employees are equal (based on Id).");
            }

            // Keep the console window open until a key is pressed.
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();  // Waits for the user to press a key before exiting the program
        }
    }
}
