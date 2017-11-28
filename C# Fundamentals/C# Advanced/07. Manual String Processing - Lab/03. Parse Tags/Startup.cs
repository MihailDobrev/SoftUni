namespace _03.Parse_Tags
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = @"<upcase>.+?<\/upcase>";

            Regex regex = new Regex(pattern);
            int matchesCount = regex.Matches(text).Count;

            const byte firstTagLenght = 8;
            const byte secondTagLenght = 9;

            for (int i = 0; i < matchesCount; i++)
            {
                int indexOpeningTag = text.IndexOf("<upcase>");
                text = text.Remove(indexOpeningTag, firstTagLenght);
                int indexClosingTag = text.IndexOf("</upcase>");
                string capitalizeText = text.Substring(indexOpeningTag, indexClosingTag-indexOpeningTag).ToUpper();
                text = text.Remove(indexClosingTag, secondTagLenght);                
                text = text.Remove(indexOpeningTag, capitalizeText.Length);
                text = text.Insert(indexOpeningTag, capitalizeText);
            }

            Console.WriteLine(text);
        }
    }
}
