namespace _05.Concatenate_Strings
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            int wordCounter = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();

            for (int i = 0; i < wordCounter; i++)
            {
                text.Append(Console.ReadLine()+" ");
            }

            Console.WriteLine(text.ToString());
        }
    }
}
