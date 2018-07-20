namespace P11_TotalBookCopies
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
                Console.WriteLine(CountCopiesByAuthor(context));
            }
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder stringbuilder = new StringBuilder();
            context.Authors
                .Select(d => new
                {
                    AuthorName = string.Concat(d.FirstName, " ", d.LastName),
                    BooksCount = d.Books.Sum(b => b.Copies)
                }
                )
                .ToDictionary(k => k.AuthorName, v => v.BooksCount)
                .OrderByDescending(v => v.Value)
                .Select(d => $"{d.Key} - {d.Value}")
                .ToList()
                .ForEach(t => stringbuilder.AppendLine(t));
            return stringbuilder.ToString().Trim();
        }
    }
}
