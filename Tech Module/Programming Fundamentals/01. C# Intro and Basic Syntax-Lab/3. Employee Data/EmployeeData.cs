
namespace Problem_3.Employee_Data
{
    using System;
    public class EmployeeData
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var id = int.Parse(Console.ReadLine());
            var salary = double.Parse(Console.ReadLine());
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine("Employee ID: " + id.ToString("D8"));
            Console.WriteLine($"Salary: {salary:F2}");
        }
    }
}
