namespace P08_BookSearch
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
                Console.WriteLine(GetBookTitlesContaining(context, input));
            }
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder stringbuilder = new StringBuilder();

            context.Books
                    .Where(b=>b.Title.ToLower().Contains(input.ToLower()))
                    .Select(b=>b.Title)
                    .OrderBy(b=>b)
                    .ToList()
                    .ForEach(b => stringbuilder.AppendLine(b));

            return stringbuilder.ToString().Trim();
        }
    }
}
