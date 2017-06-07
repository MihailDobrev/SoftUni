namespace Debugging_Exercise_Substring
{
    using System;
    public class Substring
    {
        static void Main()
        {
            string text = Console.ReadLine();
            int numberCount = int.Parse(Console.ReadLine());

            const char search = 'p';
            bool hasMatch = false;

            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == search)
                {
                    hasMatch = true;
                    
                    int length = numberCount+1;
                    string matchedString;

                    if (i+length <= text.Length)
                    {
                        matchedString = text.Substring(i, length);
                    }
                    else
                    {
                        matchedString = text.Substring(i);
                    }

                    Console.WriteLine(matchedString);
                    i += numberCount;
                }
            }

            if (!hasMatch)
            {
                Console.WriteLine("no");
            }
        }
    }
}
