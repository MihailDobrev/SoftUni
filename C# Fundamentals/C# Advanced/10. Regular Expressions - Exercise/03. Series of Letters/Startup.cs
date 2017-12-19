namespace _03.Series_of_Letters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Startup
    {
        public static void Main()
        {
            string inputLine = Console.ReadLine();

            Stack<char> stack = new Stack<char>();
            stack.Push(inputLine[0]);

            for (int index = 1; index < inputLine.Length; index++)
            {   
                char topLetterInStack = stack.Peek();
                char currentLetter=inputLine[index];

                if (topLetterInStack!= currentLetter)
                {
                    stack.Push(currentLetter);
                }

            }

            stack.Reverse().ToList().ForEach(x => Console.Write(x));
            
        }
    }
}
