namespace P03_EmployeesFullInformation
{
    using P02_DatabaseFirst.Data;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {

            using (var context = new SoftUniContext())
            {
                var employees = context
                     .Employees
                     .OrderBy(e => e.EmployeeId)
                     .Select(emp => $"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:F2}")
                     .ToArray();

                File.WriteAllLines("..\\..\\..\\output.txt", employees);
            }
            
        }
    }
}
