namespace P11_FindLatest10Projects
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
                var projects = context.Projects
                   .OrderByDescending(p => p.StartDate)
                   .Take(10)
                   .OrderBy(p => p.Name)
                   .Select(p => new
                   {
                       p.Name,
                       p.Description,
                       p.StartDate
                   })
                   .ToArray();

                using (var sr = new StreamWriter("..\\output.txt"))
                {
                    foreach (var project in projects)
                    {
                        sr.WriteLine(project.Name);
                        sr.WriteLine(project.Description);
                        sr.WriteLine(project.StartDate);
                    }
                }
               
            }
        }
    }
}
