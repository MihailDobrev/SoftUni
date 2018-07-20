namespace P10_CountBooks
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
                int lengthCheck = int.Parse(Console.ReadLine());
                Console.WriteLine(CountBooks(context, lengthCheck));
            }
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            StringBuilder stringbuilder = new StringBuilder();

            int bookCount = context.Books
                    .Where(b => b.Title.Length > lengthCheck)
                    .ToList()
                    .Count;

            return bookCount;
        }
    }
}
