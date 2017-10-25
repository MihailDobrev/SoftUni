namespace _02.Simple_Calculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SimpleCalculator
    {
        static void Main()
        {
            var input = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        
            Stack<int> addedSumStack = new Stack<int>();
            Stack<int> substractedSumStack = new Stack<int>();

            int finalSum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string letter = input[i];
                string nextLetter = input[i+1];

                if (i == 0)
                {
                    addedSumStack.Push(int.Parse(letter));
                }
                else if (letter=="+")
                {
                    addedSumStack.Push(int.Parse(nextLetter));
                    i++;
                }
                else if (letter == "-")
                {
                    substractedSumStack.Push(int.Parse(nextLetter));
                    i++;
                }
            }

            finalSum = addedSumStack.Sum() - substractedSumStack.Sum();
            Console.WriteLine(finalSum);
        }
    }
}
