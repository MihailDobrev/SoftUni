namespace P08._AddressesByTown
{
    using Microsoft.EntityFrameworkCore;
    using P02_DatabaseFirst.Data;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                using (var sr = new StreamWriter("..\\output.txt"))
                {
                    context
                        .Addresses
                        .Include(a=> a.Employees)
                        .Include(a => a.Town)
                        .OrderByDescending(a => a.Employees.Count)
                        .ThenBy(a => a.Town.Name)
                        .ThenBy(a => a.AddressText)
                        .Take(10)
                        .ToList()
                        .ForEach(a => sr.WriteLine($"{a.AddressText}, {a.Town.Name} - {a.Employees.Count} employees"));                
                }
            }
        }
    }
}
