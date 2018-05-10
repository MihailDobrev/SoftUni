namespace P03.IteratorTest
{
    using System;
    using System.Linq;

    public class Enigne
    {
        public void Run()
        {
            string input;
            ListIterator listIterator = null;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] commandArgs = input.Split();
                string command = commandArgs[0];
                commandArgs = commandArgs.Skip(1).ToArray();

                try
                {
                    switch (command)
                    {
                        case "Create":
                            listIterator = new ListIterator(commandArgs);
                            break;
                        case "Move":
                            Console.WriteLine(listIterator.Move());
                            break;
                        case "HasNext":
                            Console.WriteLine(listIterator.HasNext());
                            break;
                        case "Print":
                            listIterator.Print();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}