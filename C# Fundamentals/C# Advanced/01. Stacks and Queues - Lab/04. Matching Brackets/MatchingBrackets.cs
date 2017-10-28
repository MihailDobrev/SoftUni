﻿namespace _04.Matching_Brackets
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var indexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indexes.Push(i);
                }

                if (input[i] == ')')
                {
                    indexes.Push(i);
                    if (indexes.Count < 2)
                    {
                        return;
                    }

                    var endIndex = indexes.Pop();
                    var startIndex = indexes.Pop();
                    Console.WriteLine(input.Substring(startIndex, endIndex - startIndex + 1));
                }
            }
        }
    }
}

