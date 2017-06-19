namespace _2.Advert_Message
{
    using System;

    public class AdvertisementMessage
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            var phrases = new string[]
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };

            var events = new string[]
            {
               "Now I feel good.",
               "I have succeeded with this product.",
               "Makes miracles. I am happy of the results!",
               "I cannot believe but now I feel awesome.",
               "Try it yourself, I am very satisfied.",
               "I feel great!"
            };

            var authors = new string[]
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Elena",
                "Iva",
                "Annie",
                "Eva"
            };

            var cities = new string[]
             {"Burgas",
               "Sofia",
               "Plovdiv",
               "Varna",
               "Ruse"
             };

            Random randomOne = new Random();
            Random randomTwo = new Random();
            Random randomThree = new Random();
            Random randomFour = new Random();


            for (int i = 0; i < number; i++)
            {
                int phrase = randomOne.Next(0, phrases.Length);
                int eventRng = randomOne.Next(0, events.Length);
                int author = randomOne.Next(0, authors.Length);
                int city = randomOne.Next(0, cities.Length);
                Console.WriteLine($"{phrases[phrase]} {events[eventRng]} {authors[author]} - {cities[city]}");
            }
        }
    }
}
