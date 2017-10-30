namespace _03.Maximum_Element
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int queriesQuantity = int.Parse(Console.ReadLine());
            Stack<int> stackOfNumbers = new Stack<int>();
            int maxNumber = int.MinValue;

            for (int i = 0; i < queriesQuantity; i++)
            {
                int[] queryInput = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int typeOfQuerry = queryInput[0];

                if (typeOfQuerry == 1)
                {
                    stackOfNumbers.Push(queryInput[1]);
                    if (maxNumber < stackOfNumbers.Peek())
                    {
                        maxNumber = stackOfNumbers.Peek();
                    }
                }
                else
                {
                    if (typeOfQuerry == 2)
                    {
                        stackOfNumbers.Pop();

                        if (stackOfNumbers.Count > 0)
                        {
                            maxNumber = stackOfNumbers.Max();
                        }
                        else
                        {
                            maxNumber = int.MinValue;
                        }

                    }
                    else
                    {
                        if (typeOfQuerry == 3)
                        {
                            Console.WriteLine(maxNumber);
                        }
                    }
                     
                }

            }
        }
    }
}
