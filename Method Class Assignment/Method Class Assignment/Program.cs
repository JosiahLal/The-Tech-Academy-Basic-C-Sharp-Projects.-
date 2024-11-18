using System;


MathOperations mathOps = new MathOperations();

// Step 3: Call the method, passing in two numbers (positional arguments)
mathOps.PerformOperation(5, 10); // This will multiply 5 by 2 and display 10 as the second number.

// Step 4: Call the method, specifying the parameters by name (named arguments)
mathOps.PerformOperation(firstNumber: 8, secondNumber: 20); // Here we pass in the first number as 8 and second number as 20.

Console.WriteLine("Press any key to exit...");
Console.ReadKey(); // Keeps the console window open until the user presses a key


// Define the MathOperations class after the top-level statements
public class MathOperations
{
    // Step 1.1: Create a void method that takes two integers as parameters
    public void PerformOperation(int firstNumber, int secondNumber)
    {
        // Perform a math operation on the first integer (e.g., multiply the first number by 2)
        int result = firstNumber * 2;

        // Display the result of the operation on the first number
        Console.WriteLine($"The result of multiplying {firstNumber} by 2 is: {result}");

        // Display the second integer
        Console.WriteLine($"The second number you passed in is: {secondNumber}");
    }
}
