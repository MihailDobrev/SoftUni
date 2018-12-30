using System;

namespace _04.LinkedStack
{
    public class Program
    {
        public static void Main()
        {
            LinkedStack<int> linkedStack = new LinkedStack<int>();

            for (int i = 1; i <= 10; i++)
            {
                linkedStack.Push(i);
            }

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    int popped = linkedStack.Pop();
                    Console.WriteLine(popped);
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
           
            Console.WriteLine(string.Join(", ", linkedStack.ToArray()));
        }
    }
}
