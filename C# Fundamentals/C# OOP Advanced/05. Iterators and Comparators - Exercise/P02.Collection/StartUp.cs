namespace P02.Collection
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string input;
            var listyIterator = new ListyIterator<object>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] args = input.Split();
                string command = args[0];
                args = args.Skip(1).ToArray();

                try
                {
                    switch (command)
                    {
                        case "Create":
                            listyIterator.Create(args);
                            break;
                        case "Move":
                            Console.WriteLine(listyIterator.Move().ToString());
                            break;
                        case "Print":
                            listyIterator.Print();
                            break;
                        case "PrintAll":
                            Console.WriteLine(listyIterator.GetAllElements());
                            break;
                        case "HasNext":
                            Console.WriteLine(listyIterator.HasNext().ToString());
                            break;
                    }

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

        }
    }
}
