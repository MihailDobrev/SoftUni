namespace P14_DeleteProjectById
{
    using P02_DatabaseFirst.Data;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                var employeeProjects = context.EmployeesProjects.Where(ep => ep.ProjectId == 2);

                context.EmployeesProjects.RemoveRange(employeeProjects);

                var projectToDelete = context.Projects.Find(2);

                context.Projects.Remove(projectToDelete);

                context.SaveChanges();
                
                var projects = context.Projects
                    .Take(10).ToArray();

                using (var sr = new StreamWriter("..\\output.txt"))
                {
                    foreach (var project in projects)
                    {
                        sr.WriteLine(project.Name);
                    }
                }
        
            }
        }
    }
}
