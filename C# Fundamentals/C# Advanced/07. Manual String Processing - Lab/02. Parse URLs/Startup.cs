namespace _02.Parse_URLs
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string urlInput = Console.ReadLine();
            bool isInvalid = false;

            if (urlInput.Contains("://") &&
                urlInput.IndexOf("://") == urlInput.LastIndexOf("://"))
            {
                int protocolSeparatorIndex = urlInput.IndexOf("://");
                string afterProtocolSeparator = urlInput.Substring(protocolSeparatorIndex + 3);

                if (afterProtocolSeparator.Contains("/"))
                {
                    int serverSeparatorIndex = afterProtocolSeparator.IndexOf("/");

                    string protocol = urlInput.Substring(0, protocolSeparatorIndex);
                    string server = urlInput.Substring(protocolSeparatorIndex + 3, serverSeparatorIndex);
                    string resources = urlInput.Substring(protocolSeparatorIndex + 3 + serverSeparatorIndex + 1);

                    Console.WriteLine($"Protocol = {protocol}");
                    Console.WriteLine($"Server = {server}");
                    Console.WriteLine($"Resources = {resources}");
                }
                else
                {
                    isInvalid = true;
                }
            }
            else
            {
                isInvalid = true;
            }

            if (isInvalid)
            {
                Console.WriteLine("Invalid URL");
            }
        }
    }
}
