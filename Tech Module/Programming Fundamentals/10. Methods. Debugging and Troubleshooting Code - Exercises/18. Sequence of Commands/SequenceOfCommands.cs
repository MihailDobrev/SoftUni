
namespace Sequence_of_Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class SequenceOfCommands
    {
        private const char ArgumentsDelimiter = ' ';

        public static void Main()
        {
            int sizeOfArray = int.Parse(Console.ReadLine());

            long[] array = Console.ReadLine()
                .Split(ArgumentsDelimiter)
                .Select(long.Parse)
                .ToArray();

            var command = Console.ReadLine().Split(' ').ToArray();

            while (!command[0].Equals("stop"))
            {
                int[] args = new int[2];
                string action = command[0];

                if (command[0].Equals("add") ||
                    command[0].Equals("subtract") ||
                    command[0].Equals("multiply"))
                {
                    args[0] = int.Parse(command[1]);
                    args[1] = int.Parse(command[2]);
                    array=PerformAction(array, action, args);
                }
                else
                {
                    array = PerformAction(array, action, args);
                }

                PrintArray(array);
                Console.Write('\n');

                command = Console.ReadLine().Split(' ').ToArray();
            }
        }

        static long[] PerformAction(long[] arr, string action, int[] args)
        {
            long[] array = arr.Clone() as long[];
            
            int pos = args[0];
            int value = args[1];

            switch (action)
            {
                case "multiply":
                    array[pos-1] *= value;
                    break;
                case "add":
                    array[pos-1] += value;
                    break;
                case "subtract":
                    array[pos-1] -= value;
                    break;
                case "lshift":
                    array=ArrayShiftLeft(array);
                    break;
                case "rshift":
                    array=ArrayShiftRight(array);
                    break;
            }
            return array;
        }

        private static long[] ArrayShiftRight(long[] array)
        {
            var list = new List<long>();
            long end = array[array.Length-1];
            list.Add(end);
            var arrayToList = array.ToList();
            list.AddRange(arrayToList);
            list.RemoveAt(list.Count - 1);
            array=list.ToArray();
            return array;
        }

        private static long[] ArrayShiftLeft(long[] array)
        {
            var list = new List<long>();
            long first = array[0];
            var arrayToList = array.ToList();
            arrayToList.RemoveAt(0);
            list.AddRange(arrayToList);
            list.Add(first);
            array = list.ToArray();
            return array;
        }

        private static void PrintArray(long[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
