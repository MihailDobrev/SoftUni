namespace P05_BookTitlesByCategory
{
    using BookShop.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new BookShopContext())
            {
                string input = Console.ReadLine();
                Console.WriteLine(GetBooksByCategory(context, input));
            }
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder stringbuilder = new StringBuilder();
            List<string> categories = new List<string>();
            input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList()
                        .ForEach(c=>categories.Add(c.ToLower()));

            var books = context.Categories
                .Select(s => new
            {
                CategoryName = s.Name,
                BookTitlesForCategory = s.CategoryBooks.Select(x => new
                {
                    x.Book.Title
                }).ToArray()
            }).ToArray();

            List<string> bookTitles = new List<string>();

            foreach (var book in books.Where(b => categories.Any(c => c == b.CategoryName.ToLower())))
            {
                foreach (var bookTitle in book.BookTitlesForCategory)
                {
                    bookTitles.Add(bookTitle.Title);
                }
            }

            bookTitles.OrderBy(b => b)
                .ToList()
                .ForEach(t => stringbuilder.AppendLine(t));

            return stringbuilder.ToString().Trim();
        }
    }
}
