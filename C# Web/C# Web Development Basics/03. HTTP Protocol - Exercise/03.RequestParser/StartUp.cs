namespace _03.RequestParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static string HttpResponceHeader =
            "HTTP/1.1 {0}\nContent-Length: {1}\nContent-Type: text/plain\n\n{2}";

        private static Dictionary<int, string> StatusTextByResponseCode =
            new Dictionary<int, string>()
            {
                { 200, "OK" },
                { 404, "Not Found" }
            };

        public static void Main()
        {
            string input = Console.ReadLine().ToLower();
            var pathsByMethods = new Dictionary<string, HashSet<string>>();

            while (input != "END")
            {
                string[] splitInput = input.Substring(1).Split('/');

                string path = splitInput[0];
                string method = splitInput[1];

                if (!pathsByMethods.ContainsKey(method))
                {
                    pathsByMethods.Add(method, new HashSet<string> { path });

                }
                else
                {
                    pathsByMethods[method].Add(path);
                }

                input = Console.ReadLine();
            }

            string request = Console.ReadLine().ToLower();

            string[] requestSplit = request.Split(' ');

            string requestMethod = requestSplit[0];

            string requestPath = requestSplit[1].Substring(1);

            string responsePath = pathsByMethods.ContainsKey(requestMethod)
                ? pathsByMethods[requestMethod].FirstOrDefault(p => p == requestPath)
                : string.Empty;

            string response = string.Empty;

            if (string.IsNullOrEmpty(responsePath))
            {
                var responseStatusCode = $"{StatusTextByResponseCode.Keys.FirstOrDefault(k => k == 404)} {StatusTextByResponseCode[404]}";
                response = string.Format(
                    HttpResponceHeader,
                    responseStatusCode,
                    StatusTextByResponseCode[404].Length,
                    StatusTextByResponseCode[404]);
            }
            else
            {
                var responseStatusCode = $"{StatusTextByResponseCode.Keys.FirstOrDefault(k => k == 200)} {StatusTextByResponseCode[200]}";
                response = string.Format(
                    HttpResponceHeader,
                    responseStatusCode,
                    StatusTextByResponseCode[200].Length,
                    StatusTextByResponseCode[200]);
            }

            Console.WriteLine(response);
        }
    }
}
