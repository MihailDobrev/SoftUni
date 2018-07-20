namespace P09_BookSearchByAuthor
{
    using BookShop.Data;
    using Microsoft.EntityFrameworkCore;
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
                Console.WriteLine(GetBooksByAuthor(context, input));
            }
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder stringbuilder = new StringBuilder();

            context.Books
                    .Include(b => b.Author)
                    .OrderBy(b => b.BookId)
                    .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                    .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                    .ToList()
                    .ForEach(b => stringbuilder.AppendLine(b));

            return stringbuilder.ToString().Trim();
        }
    }
}
