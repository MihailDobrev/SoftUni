namespace MiniORM.App
{
    using MiniORM.App.Data;
    using MiniORM.App.Data.Entities;
    using System.Linq;
    public class StartUp
    {
        public static void Main()
        {
            const string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=MiniORM;Integrated Security=True";

            var context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Gosho",
                LastName = "Ivanov",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true,
            });

            var employee = context.Employees.Last();

            employee.FirstName = "Pesho";

            context.SaveChanges();

            //Test
            System.Console.WriteLine($"First Name:{employee.FirstName}, Last Name:{employee.LastName}");

        }
    }
}
