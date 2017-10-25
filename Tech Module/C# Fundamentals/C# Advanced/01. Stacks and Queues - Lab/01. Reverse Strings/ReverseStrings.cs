namespace _01.Reverse_Strings
{
    using System;
    using System.Collections.Generic;

    class ReverseStrings
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (var letter in input)
            {
                stack.Push(letter);
            }
            char output;

            foreach (var letter in input)
            {
                output = stack.Pop();
                Console.Write(output);
            }
        }
    }
}
