namespace P01_AgeRestriction
{
    using BookShop.Data;
    using BookShop.Models;
    using System;
    using System.Linq;
    using System.Text;
    public class StartUp
    {
        public static void Main()
        {
            string command = Console.ReadLine();

            using (var context = new BookShopContext())
            {
                Console.WriteLine(GetBooksByAgeRestriction(context, command));;
            }     
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder stringbuilder = new StringBuilder();
            var formattedCommand = string.Concat(char.ToUpper(command[0]),command.Substring(1).ToLower());
            AgeRestriction ageRestriction = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), formattedCommand);

            context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList()
                .ForEach(t => stringbuilder.AppendLine(t));

            return stringbuilder.ToString().Trim();
        }
    }
}
