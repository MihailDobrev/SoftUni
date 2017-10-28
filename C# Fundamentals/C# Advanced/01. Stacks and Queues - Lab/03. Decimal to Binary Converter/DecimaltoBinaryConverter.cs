namespace _03.Decimal_to_Binary_Converter
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            if (input==0)
            {
                Console.WriteLine(input);
            }
            else
            {
                while (input > 0)
                {
                    stack.Push(input % 2);
                    input = input / 2;
                }

                int elementsCount = stack.Count;

                for (int i = 0; i < elementsCount; i++)
                {
                    int removedNumber = stack.Pop();
                    Console.Write(removedNumber);
                }
            }
           
        }
    }
}
