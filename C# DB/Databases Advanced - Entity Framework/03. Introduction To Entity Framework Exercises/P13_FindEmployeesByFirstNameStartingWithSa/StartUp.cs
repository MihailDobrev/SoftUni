namespace P13_FindEmployeesByFirstNameStartingWithSa
{
    using P02_DatabaseFirst.Data;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                var employees = context.Employees
                    .Where(e => e.FirstName.StartsWith("Sa"))
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToArray();

                using (var sr = new StreamWriter("..\\output.txt"))
                {
                    foreach (var employee in employees)
                    {
                        sr.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
                    }
                }

            }
        }
    }
}
