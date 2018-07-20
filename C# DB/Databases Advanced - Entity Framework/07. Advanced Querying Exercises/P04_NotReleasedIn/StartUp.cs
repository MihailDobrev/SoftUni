namespace P04_NotReleasedIn
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
                int releaseYearNotIncluded = int.Parse(Console.ReadLine());
                Console.WriteLine(GetBooksNotRealeasedIn(context, releaseYearNotIncluded));
            }
        }

        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            StringBuilder stringbuilder = new StringBuilder();
            context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList()
                .ForEach(t => stringbuilder.AppendLine(t));
            return stringbuilder.ToString().Trim();
        }
    }
}
