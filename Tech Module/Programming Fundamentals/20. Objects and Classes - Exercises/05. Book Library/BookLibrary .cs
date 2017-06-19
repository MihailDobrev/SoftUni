namespace _5.Book_Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Globalization;

    public class BookLibrary
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

            Library library = new Library() { Name = "Random", Books = books };

            Dictionary<string, double> authors = new Dictionary<string, double>();

            foreach (var book in library.Books)
            {
                if (authors.ContainsKey(book.Author))
                {
                    authors[book.Author] += book.Price;
                }
                else
                {
                    authors[book.Author] = book.Price;
                }
            }

            foreach (var pair in authors.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value:F2}");
            }
        }

        private static Book ReadBook(string input)
        {
            var properties=input.Split(' ')
                    .Select(x => x)
                    .ToArray();
            var date = properties[3].Split('.').Select(x => x).ToArray();
            Book book = new Book() { Title = properties[0], Author = properties[1], Publisher = properties[2], ReleaseDate = DateTime.ParseExact(properties[3], "dd.MM.yyyy", CultureInfo.InvariantCulture), ISBNnumber=properties[4], Price=double.Parse(properties[5]) };
            return book;
        }
    }
}
