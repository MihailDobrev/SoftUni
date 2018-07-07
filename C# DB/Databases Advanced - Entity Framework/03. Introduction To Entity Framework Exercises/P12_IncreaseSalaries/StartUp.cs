namespace P12_IncreaseSalaries
{
    using P02_DatabaseFirst.Data;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (var context=new SoftUniContext())
            {
                var employees = context.Employees
                    .Where(e => e.Department.Name == "Engineering" ||
                        e.Department.Name == "Tool Design" ||
                        e.Department.Name == "Marketing" ||
                        e.Department.Name == "Information Services")
                    .OrderBy(e=>e.FirstName)
                    .ThenBy(e=>e.LastName)
                    .ToArray();

                using (var sr = new StreamWriter("..\\output.txt"))
                {
                    foreach (var employee in employees)
                    {
                        employee.Salary += employee.Salary * 0.12m;

                        sr.WriteLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
                    }
                }

                context.SaveChanges();
            }

        }
    }
}
