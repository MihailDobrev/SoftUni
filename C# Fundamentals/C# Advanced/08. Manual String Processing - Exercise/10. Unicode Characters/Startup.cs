namespace _10.Unicode_Characters
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            for (int index = 0; index < text.Length; index++)
            {
                string unicode = "\\u" + ((int)text[index]).ToString("X4").ToLower();
                sb.Append(unicode);
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
