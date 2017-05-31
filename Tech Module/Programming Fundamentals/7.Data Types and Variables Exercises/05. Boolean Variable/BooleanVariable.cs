

namespace _05.Boolean_Variable
{
    using System;

    public class BooleanVariable
    {
        static void Main()
        {
            string text = Console.ReadLine();
            bool boolean = Convert.ToBoolean(text);
            if (boolean)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
