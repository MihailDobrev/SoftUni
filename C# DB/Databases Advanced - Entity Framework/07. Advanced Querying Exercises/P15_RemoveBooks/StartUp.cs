namespace P15_RemoveBooks
{
    using BookShop.Data;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new BookShopContext())
            {
                int booksRemoved = RemoveBooks(context);
                Console.WriteLine($"{booksRemoved} books were deleted");
            }
        }

        public static int RemoveBooks(BookShopContext context)
        {

            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            int booksRemoved = books.Length;

            context.RemoveRange(books);
            context.SaveChanges();

            return booksRemoved;
        }
    }
}
