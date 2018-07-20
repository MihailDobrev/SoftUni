namespace P12_ProfitByCategory
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
                Console.WriteLine(GetTotalProfitByCategory(context));
            }
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder stringbuilder = new StringBuilder();
            context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    TotalProfit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .ToDictionary(k => k.CategoryName, v => v.TotalProfit)
                .OrderByDescending(d => d.Value)
                .ThenBy(d => d.Key)
                .Select(d => $"{d.Key} ${d.Value:F2}")
                .ToList()
                .ForEach(t => stringbuilder.AppendLine(t));
            return stringbuilder.ToString().Trim();
        }
    }
}
