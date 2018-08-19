namespace _02.ValidateURL
{
    using System;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string pattern = @"^(?<Protocol>((?<https>https))|(?<http>http)):\/\/(?<host>[a-z0-9][a-z0-9-]*\.[a-z0-9][a-z0-9-]*):*(?<port>(?(https)447)*(?(http)80)*)(?<path>\/*[a-z\/.]*)\??(?<querry>[a-zA-Z0-9&=]*)#*(?<fragment>[a-z]*)$";
            Regex regex = new Regex(pattern);

            string inputUrl = ReadUrl();
            string result = CheckURL(inputUrl);
            Console.WriteLine(result);

        }

        private static string CheckURL(string inputUrl)
        {
            string decodedUrl = DecodedUrl(inputUrl);

            string result = CheckValid(decodedUrl);

            return result;
        }

        private static string CheckValid(string decodedUrl)
        {
            string pattern = @"(?<protocol>((?<https>https))|(?<http>http)):\/\/(?<host>[a-z0-9][a-z0-9-]*\.[a-z0-9][a-z0-9-]*):*(?<port>(?(https)443)*(?(http)80)*)(?<path>\/*[a-z\/.]*)\??(?<querry>[a-zA-Z0-9&=]*)#*(?<fragment>[a-z]*)$";

            Regex regex = new Regex(pattern);

            if (regex.IsMatch(decodedUrl))
            {
                Match match = regex.Match(decodedUrl);
                StringBuilder sb = new StringBuilder();

                string protocol = match.Groups["protocol"].Value;
                sb.AppendLine($"Protocol: {protocol}");

                string host = match.Groups["host"].Value;
                sb.AppendLine($"Host: {host}");

                string port = match.Groups["port"].Value;

                if (port == string.Empty)
                {
                    if (protocol == "http")
                    {
                        port = "80";
                    }
                    else if (protocol == "https")
                    {
                        port = "443";
                    }
                }

                sb.AppendLine($"Port: {port}");


                string path = match.Groups["path"].Value;

                if (path == string.Empty)
                {
                    path = "/";
                }
                sb.AppendLine($"Path: {path}");

                string querry = match.Groups["querry"].Value;

                if (querry != string.Empty)
                {
                    sb.AppendLine($"Query: {querry}");
                }

                string fragment = match.Groups["fragment"].Value;

                if (fragment != string.Empty)
                {
                    sb.AppendLine($"Fragment: {fragment}");
                }

                return sb.ToString().TrimEnd();
            }
            
                return "Invalid URL";
            
        }

        private static string DecodedUrl(string inputUrl)
        {
            return WebUtility.UrlDecode(inputUrl);
        }

        private static string ReadUrl()
        {
            return Console.ReadLine();
        }
    }
}
