namespace P14_IncreasePrices
{
    using BookShop.Data;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new BookShopContext())
            {
                IncreasePrices(context);
            }
        }

        public static void IncreasePrices(BookShopContext context)
        {
            context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList()
                .ForEach(b => b.Price += 5);
            context.SaveChanges();
        }
    }
}
