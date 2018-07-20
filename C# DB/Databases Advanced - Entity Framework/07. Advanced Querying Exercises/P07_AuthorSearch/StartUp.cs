namespace P07_AuthorSearch
{
    using BookShop.Data;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new BookShopContext())
            {
                string input = Console.ReadLine();
                Console.WriteLine(GetAuthorNamesEndingIn(context, input));
            }
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder stringbuilder = new StringBuilder();
            
            context.Authors
                    .Where(a => a.FirstName.EndsWith(input))
                    .Select(a => $"{a.FirstName} {a.LastName}")
                    .OrderBy(a => a)
                    .ToList()
                    .ForEach(a => stringbuilder.AppendLine(a));

            return stringbuilder.ToString().Trim();
        }
    }
}
