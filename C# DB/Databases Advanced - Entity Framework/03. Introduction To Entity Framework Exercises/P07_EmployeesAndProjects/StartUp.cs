namespace P07_EmployeesAndProjects
{
    using P02_DatabaseFirst.Data;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                var employeesProjects = context.Employees
                    .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001
                        && ep.Project.StartDate.Year <= 2003))
                      .Select(e => new
                      {
                          EmployeeName = e.FirstName + " " + e.LastName,
                          ManagerName = e.Manager.FirstName + " " + e.Manager.LastName,
                          Projects = e.EmployeesProjects.Select(p => new
                          {
                              ProjectName = p.Project.Name,
                               p.Project.StartDate,
                               p.Project.EndDate
                          }).ToArray()
                      })
                      .Take(30)
                      .ToArray();

                using (var sr = new StreamWriter("..\\output.txt"))
                {
                    foreach (var group in employeesProjects)
                    {

                        sr.WriteLine($"{group.EmployeeName} - Manager: {group.ManagerName}");

                        foreach (var project in group.Projects)
                        {
                            sr.WriteLine($"--{project.ProjectName} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} " +
                                $"- {project.EndDate?.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) ?? "not finished"} ");
                        }
                    }
                }

            }

        }
    }
}

