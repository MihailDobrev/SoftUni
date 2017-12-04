namespace _01.Reverse_String
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            string text=Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            for (int index = text.Length-1; index >=0 ; index--)
            {
                sb.Append(text[index]);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
