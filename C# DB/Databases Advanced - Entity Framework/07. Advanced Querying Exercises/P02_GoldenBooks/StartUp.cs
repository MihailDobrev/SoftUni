namespace P02_GoldenBooks
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
            using (var context = new BookShopContext())
            {
                Console.WriteLine(GetGoldenBooks(context));
            }
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder stringbuilder = new StringBuilder();
            context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b=>b.BookId)
                .Select(b => b.Title)
                .ToList()
                .ForEach(t => stringbuilder.AppendLine(t));
            return stringbuilder.ToString().Trim();
        }
    }
}
