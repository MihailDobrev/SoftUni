namespace _01.URLDecode
{
    using System;
    using System.Net;

    public class StartUp
    {
        public static void Main()
        {
            string inputUrl = Console.ReadLine();
            var decodedUrl = WebUtility.UrlDecode(inputUrl);
            Console.WriteLine(decodedUrl);
        }
    }
}
