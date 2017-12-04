namespace _15.Melrah_Shake
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            string randomCharacters = Console.ReadLine();
            string pattern = Console.ReadLine();

            StringBuilder messages = new StringBuilder();

            if (pattern.Length == 0)
            {
                Console.WriteLine("No shake.");
                Console.WriteLine(randomCharacters);
                return;
            }

            while (true)
            {
                int firstOccureence = randomCharacters.IndexOf(pattern);
                int lastOccureence = randomCharacters.LastIndexOf(pattern);

                if (firstOccureence > -1 && lastOccureence > -1 && pattern.Length > 0)
                {
                    randomCharacters = randomCharacters.Remove(lastOccureence, pattern.Length);
                    randomCharacters = randomCharacters.Remove(firstOccureence, pattern.Length);
                    messages.AppendLine("Shaked it.");

                    pattern = pattern.Remove(pattern.Length / 2, 1);

                }
                else
                {
                    messages.AppendLine("No shake.");
                    break;
                }
            }

            Console.Write(messages.ToString());
            Console.WriteLine(randomCharacters);
        }
    }
}
