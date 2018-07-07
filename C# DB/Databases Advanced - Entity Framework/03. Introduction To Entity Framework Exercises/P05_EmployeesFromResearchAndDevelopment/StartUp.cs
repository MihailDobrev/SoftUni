namespace P05_EmployeesFromResearchAndDevelopment
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
                var selectedEmployees = context.Employees
                .Where(e => e.Department.Name == "Research and Development ")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => $"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:f2}")
                .ToArray();

                File.WriteAllLines("..\\..\\..\\output.txt", selectedEmployees);
            }
        }
    }
}
