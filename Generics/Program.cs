using Generics.src;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Security.AccessControl;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var studentStore = new Store<Student>();
            studentStore.Add(new Student(1, "Alice"));
            studentStore.Add(new Student(2, "Bob"));
            studentStore.Add(new Student(3, "Charlie"));
            studentStore.Add(new Student(4, "Diana"));
            studentStore.Add(new Student(5, "Ethan"));

            var courseStore = new Store<Course>();
            courseStore.Add(new Course(101, "C# Basics", 199.99m));
            courseStore.Add(new Course(102, "ASP.NET Core", 299.99m));
            courseStore.Add(new Course(103, "Design Patterns", 249.99m));

            Console.WriteLine($"Retrieved Student (Id=2): {studentStore.GetById(2)?.Name}");
            Console.WriteLine($"Retrieved Course (Id=102): {courseStore.GetById(102)?.Title}\n");
            try
            {
                studentStore.Add(new Student(1, "Duplicate Alice"));
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Caught expected exception: {ex.Message}\n");
            }

            Console.WriteLine("--- Students Page 2 (Size 2) ---");
            var page2Students = studentStore.GetAll().Page(2, 2);
            foreach (var student in page2Students)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}");
            }

            List<Course> plainCourseList = new()
            {
              new Course(201, "SQL Fundamentals", 149.99m),
              new Course(202, "Docker for Developers", 179.99m)
            };

            var foundCourse = plainCourseList.FindById(202);
            Console.WriteLine($"\nFound Course in Plain List (Id=202): {foundCourse?.Title}");


        }
    }
    
}
