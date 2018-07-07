namespace P15_RemoveTowns
{
    using P02_DatabaseFirst.Data;
    using System;
    using System.Linq;
    public class StartUp
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                string townForDeleting = ReadCityForDeleting();

                var townId = context.Towns
                    .Where(t => t.Name == townForDeleting)
                    .Select(t => t.TownId)
                    .FirstOrDefault();

                int[] addressIds = context.Addresses
                    .Where(a => a.TownId == townId)
                    .Select(a => a.AddressId)
                    .ToArray();

                SetEmployeeAddressesToNull(context, addressIds);

                RemoveAddresses(context, townId);

                RemoveTown(context, townId);

                context.SaveChanges();
            }

        }

        private static void SetEmployeeAddressesToNull(SoftUniContext context, int[] addressIds)
        {
            var affectedEmployeesFromTownDeleting = context.Employees
                .Where(e => addressIds.Any(ai => ai == e.AddressId))
                .ToArray();

            foreach (var employee in affectedEmployeesFromTownDeleting)
            {
                employee.AddressId = null;
            }
        }

        private static void RemoveAddresses(SoftUniContext context, int townId)
        {
            var addresses = context.Addresses
                .Where(a => a.TownId == townId)
                .ToArray();

            var town = context.Towns
                .Where(t => t.TownId == townId)
                .Select(t => t.Name)
                .FirstOrDefault();

            int addressesCount = addresses.Length;

            context.RemoveRange(addresses);

            if (addressesCount > 1)
            {
                Console.WriteLine($"{addressesCount} addresses in {town} were deleted");
            }
            else if (addressesCount == 1)
            {
                Console.WriteLine($"{addressesCount} address in {town} was deleted");
            }

        }

        private static void RemoveTown(SoftUniContext context, int townId)
        {
            var town = context.Towns
               .Find(townId);

            context.Remove(town);
        }

        private static string ReadCityForDeleting()
        {
            return Console.ReadLine();
        }
    }
}
