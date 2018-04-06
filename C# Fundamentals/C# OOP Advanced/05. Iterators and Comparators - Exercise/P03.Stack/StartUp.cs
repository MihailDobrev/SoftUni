namespace P03.Stack
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Stack<int> stack = FillStack();
            PrintStack(stack);
            PrintStack(stack);
        }

        private static Stack<int> FillStack()
        {
            Stack<int> stack = new Stack<int>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] args = input.Split(new char[] {',',' '},StringSplitOptions.RemoveEmptyEntries);
                string command = args[0];
                args = args.Skip(1).ToArray();

                try
                {
                    switch (command)
                    {
                        case "Push":
                            foreach (var arg in args)
                            {
                                stack.Push(int.Parse(arg));
                            }
                            break;
                        case "Pop":
                            stack.Pop();
                            break;
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("No elements");
                }
               
            }
            return stack;
        }

        private static void PrintStack(Stack<int> stack)
        {
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
