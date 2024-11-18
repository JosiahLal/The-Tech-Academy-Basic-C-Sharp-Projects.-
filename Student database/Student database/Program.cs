using System;
using System.Data.Entity;
using System.Linq;

namespace StudentApp
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public StudentContext() : base("name=StudentDatabase") { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new StudentContext())
            {
                context.Database.Initialize(true);  // Ensure database is created if it doesn't exist

                var student = new Student { Name = "Josiah Lal", Age = 20 }; // Create a new student

                context.Students.Add(student); // Add the student to the context

                context.SaveChanges(); // Save changes to the database

                var savedStudent = context.Students.FirstOrDefault(); // Retrieve the first student from the database

                Console.WriteLine($"Student added: {savedStudent.Name}, Age: {savedStudent.Age}"); // Display the student's details
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(); // Wait for user input before closing the application
        }
    }
}
