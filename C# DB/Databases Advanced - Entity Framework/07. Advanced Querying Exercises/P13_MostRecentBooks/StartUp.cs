namespace P13_MostRecentBooks
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
                Console.WriteLine(GetMostRecentBooks(context));
            }
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder stringbuilder = new StringBuilder();

            var categoriesWithTop3ReleasedBooks = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Top3ReleasedBooks = c.CategoryBooks.Select(b => new
                    {
                        b.Book.Title,
                        b.Book.ReleaseDate
                    })
                    .OrderByDescending(b => b.ReleaseDate)
                    .Take(3)
                    .ToArray()
                })
                .ToArray();

            foreach (var categories in categoriesWithTop3ReleasedBooks)
            {
                stringbuilder.AppendLine($"--{categories.CategoryName}");

                foreach (var book in categories.Top3ReleasedBooks)
                {
                    stringbuilder.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }
            return stringbuilder.ToString().Trim();
        }
    }
}
