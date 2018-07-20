namespace P06_ReleasedBeforeDate
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
                string date = Console.ReadLine();
                Console.WriteLine(GetBooksReleasedBefore(context, date));
            }
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder stringbuilder = new StringBuilder();

            int[] dateParams = date.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            DateTime dateTime = new DateTime(dateParams[2], dateParams[1], dateParams[0]);

            context.Books
                    .OrderByDescending(b => b.ReleaseDate)
                    .Where(b => b.ReleaseDate < dateTime)
                    .ToList()
                    .ForEach(b => stringbuilder.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:F2}"));

            return stringbuilder.ToString().Trim();
        }
    }
}
