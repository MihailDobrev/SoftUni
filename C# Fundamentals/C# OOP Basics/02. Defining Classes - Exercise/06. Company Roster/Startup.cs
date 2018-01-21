using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        int numberOfEmployees = int.Parse(Console.ReadLine());
        List<Employee> employees = new List<Employee>();

        for (int line = 1; line <= numberOfEmployees; line++)
        {
            string[] inputArgs = Console.ReadLine().Split();

            int numberOfArgs = inputArgs.Length;
            Employee employee = new Employee(inputArgs[0], double.Parse(inputArgs[1]), inputArgs[2], inputArgs[3], "n/a", -1);

            if (numberOfArgs > 4)
            {
                int parsed;
                var isdigit = int.TryParse(inputArgs[4], out parsed);

                if (isdigit)
                {
                    employee.Age = parsed;
                }
                else
                {
                    employee.Email = inputArgs[4];
                }

                if (inputArgs.Length > 5)
                {
                    if (isdigit)
                    {
                        employee.Email = inputArgs[5];
                    }
                    else
                    {
                        employee.Age = int.Parse(inputArgs[5]);
                    }
                }
            }
            employees.Add(employee);
        }

        var groupedEmployeesWithBiggestSalary = employees.GroupBy(e => e.Department).OrderByDescending(g => g.Select(d => d.Salary).Sum()).First();


        Console.WriteLine($"Highest Average Salary: {groupedEmployeesWithBiggestSalary.Key}");
        Console.WriteLine(string.Join(Environment.NewLine, groupedEmployeesWithBiggestSalary.OrderByDescending(x=>x.Salary).Select(e => $"{e.Name} {e.Salary:F2} {e.Email} {e.Age}")));
    }
}
