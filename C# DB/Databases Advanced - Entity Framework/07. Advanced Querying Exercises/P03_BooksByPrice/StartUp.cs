namespace P03_BooksByPrice
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
                Console.WriteLine(GetBooksByPrice(context));
            }
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder stringbuilder = new StringBuilder();
            context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => $"{b.Title} - ${b.Price}")
                .ToList()
                .ForEach(t => stringbuilder.AppendLine(t));
            return stringbuilder.ToString();
        }
    }
}
