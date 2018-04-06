namespace P01.ListyIterator
{
    using System;
    using System.Linq;
    public class StartUp
    {
        public static void Main()
        {
            string input;
            var listyIterator = new ListyIterator<object>();

            while ((input=Console.ReadLine())!="END")
            {
                string[] args = input.Split();
                string command = args[0];
                args = args.Skip(1).ToArray();

                switch (command)
                {
                    case "Create":
                        listyIterator.Create(args);
                        break;
                    case "Move":
                        Console.WriteLine(listyIterator.Move().ToString());
                        break;
                    case "Print":
                        try
                        {
                            listyIterator.Print();
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }                     
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext().ToString());
                        break;
                    default:
                        break;
                }
            }
            
        }
    }
}
