namespace _01._Odd_Lines
{
    using System;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            StreamReader reader = new StreamReader("../Resources/text.txt");
            using (reader)
            {
                int lineCounter = 0;
                string line = reader.ReadLine();

                while (line != null)
                {
                    if (lineCounter % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }
                    lineCounter++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}
