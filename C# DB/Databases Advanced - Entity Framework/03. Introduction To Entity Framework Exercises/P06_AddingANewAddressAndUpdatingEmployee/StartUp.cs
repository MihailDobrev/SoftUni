namespace P06_AddingANewAddressAndUpdatingEmployee
{
    using P02_DatabaseFirst.Data;
    using P02_DatabaseFirst.Data.Models;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                var address = new Address()
                {
                     AddressText="Vitoshka 15",
                     TownId = 4
                };
                var employees = context.Employees;
                context.Addresses.Add(address);

                var searchedEmployee = employees
                    .FirstOrDefault(e => e.LastName == "Nakov");

                searchedEmployee.Address = address;

                context.SaveChanges();

                var addressesOfEmployees = employees
                    .OrderByDescending(e => e.AddressId)
                    .Take(10)
                    .Select(e => e.Address.AddressText)
                    .ToArray();

                File.WriteAllLines("..\\..\\..\\output.txt", addressesOfEmployees);
            };
        }
    }
}
