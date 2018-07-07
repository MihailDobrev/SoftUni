namespace P09_Employee147
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
                    var employeesWithProjects = context.Employees
                  .Where(e => e.EmployeeId == 147)
                  .Select(e => new
                      {
                          e.FirstName,
                          e.LastName,
                          e.JobTitle,
                          Projects = e.EmployeesProjects.Select(p => new
                          {
                              ProjectName = p.Project.Name
                          })
                          .OrderBy(s => s.ProjectName)
                          .ToArray()
                      })
                  .ToArray();


                    foreach (var group in employeesWithProjects)
                    {
                        sr.WriteLine($"{group.FirstName} {group.LastName} - {group.JobTitle}");

                        foreach (var project in group.Projects)
                        {
                            sr.WriteLine(project.ProjectName);
                        }
                    }
                }
            }
        }
    }
}
