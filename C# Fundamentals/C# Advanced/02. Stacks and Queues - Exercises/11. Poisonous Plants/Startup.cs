namespace _11.Poisonous_Plants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int totalPlants = int.Parse(Console.ReadLine());

            List<int> plants = Console.ReadLine().Split().Select(int.Parse).ToList();
            Queue<int> queue = new Queue<int>();
            Stack<int> stack = new Stack<int>();
            plants.ForEach(x => queue.Enqueue(x));
            stack.Push(queue.Dequeue());


            bool plantsDying = true;
            int dayCounter = 0;
            int removedValue = 0;
            int previousValue = 0;

            while (plantsDying)
            {
                stack.Push(queue.Dequeue());

                while (queue.Count > 0)
                {
                    int nextValue = queue.Peek();

                    if (removedValue != 0)
                    {
                        previousValue = removedValue;
                        removedValue = 0;
                    }
                    else
                    {
                        previousValue = stack.Peek();
                    }

                    if (previousValue < nextValue)
                    {
                        removedValue = queue.Dequeue();
                    }
                    else
                    {
                        stack.Push(queue.Dequeue());
                    }
                }

                dayCounter++;
                stack.Reverse().ToList().ForEach(x => queue.Enqueue(x));
                stack.Clear();

                List<int> queueDescendingOrder = queue.ToList().OrderByDescending(x => x).ToList();

                if (queueDescendingOrder.SequenceEqual(queue.ToList()))
                {
                    plantsDying = false;
                }
            }
            Console.WriteLine(dayCounter);
        }
    }
}
