using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CalculateSequenceWithAQueue
{
    public class Program
    {
        public static void Main()
        {
            Queue<int> queue = new Queue<int>();
            Queue<int> sequence = new Queue<int>();

            int num = int.Parse(Console.ReadLine());

            queue.Enqueue(num);
            sequence.Enqueue(num);

            while (sequence.Count <= 50)
            {
                num = queue.Dequeue();
                sequence.Enqueue(num + 1);
                queue.Enqueue(num + 1);

                sequence.Enqueue(2 * num + 1);
                queue.Enqueue(2 * num + 1);

                sequence.Enqueue(num + 2);
                queue.Enqueue(num + 2);
            }

            Console.WriteLine(string.Join(", ", sequence.ToArray().Take(50)));

        }
    }
}
