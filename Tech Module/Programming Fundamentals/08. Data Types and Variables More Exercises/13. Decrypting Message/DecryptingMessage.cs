

namespace DecryptingMessage
{
    using System;

    public class DecryptingMessage
    {
        static void Main()
        {
            byte key = byte.Parse(Console.ReadLine());
            byte n = byte.Parse(Console.ReadLine());
            char[] message = new char[n];

            for (int i = 0; i < n; i++)
            {
                int letterASCIcode = key + char.Parse(Console.ReadLine());
                char letter = (char)letterASCIcode;
                message[i] = letter;
            }
            Console.WriteLine(string.Join("", message));
        }
    }
}
