namespace P10._DepartmentsWithMoreThan5Employees
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
                using (var sr = new StreamWriter("..\\output.txt"))
                {

                    var departmentsWithEmployeees = context.Departments
                        .Where(d => d.Employees.Count > 5)
                        .OrderBy(d => d.Employees.Count)
                        .ThenBy(d => d.Name)
                        .Select(d => new
                        {
                            DepartmentName = d.Name,
                            Manager = string.Concat(d.Manager.FirstName, " ", d.Manager.LastName),
                            Employees = d.Employees.Select(e => new
                            {
                                e.FirstName,
                                e.LastName,
                                e.JobTitle
                            })
                            .OrderBy(e => e.FirstName)
                            .ThenBy(e => e.LastName)
                            .ToArray()
                        })
                        .ToArray();

                    foreach (var group in departmentsWithEmployeees)
                    {
                        sr.WriteLine($"{group.DepartmentName} - {group.Manager}");

                        foreach (var e in group.Employees)
                        {
                            sr.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                        }
                        sr.WriteLine(new string('-', 10));
                    }
                }
            }
        }
    }
}
