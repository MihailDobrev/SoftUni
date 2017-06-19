namespace _6.Book_Library_Mod
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class BookLibraryModification
    {
        static void Main()
        {
            int numberOfBooks = int.Parse(Console.ReadLine());
            List<Book> books = new List<Book>();

            for (int i = 0; i < numberOfBooks; i++)
            {
                Book book = ReadBook(Console.ReadLine());
                books.Add(book);
            }
            
            DateTime stopDate=DateTime.ParseExact(Console.ReadLine(),"dd.MM.yyyy", CultureInfo.InvariantCulture);

            Dictionary<string, DateTime> titles = new Dictionary<string, DateTime>();

            foreach (var book in books)
            {
               titles[book.Title]= book.ReleaseDate;
            }

            foreach (var pair in titles.OrderBy(x => x.Value).ThenBy(x => x.Key))
            {
                if (pair.Value>stopDate)
                {
                    Console.WriteLine($"{pair.Key} -> {pair.Value.ToString("dd.MM.yyyy",CultureInfo.InvariantCulture)}");
                }           
            }
        }

        private static Book ReadBook(string input)
        {
            var properties = input.Split(' ')
                    .Select(x => x)
                    .ToArray();
            var date = properties[3].Split('.').Select(x => x).ToArray();
            Book book = new Book() { Title = properties[0], Author = properties[1], Publisher = properties[2], ReleaseDate = DateTime.ParseExact(properties[3], "dd.MM.yyyy", CultureInfo.InvariantCulture), ISBNnumber = properties[4], Price = double.Parse(properties[5]) };
            return book;
        }
    }
}
