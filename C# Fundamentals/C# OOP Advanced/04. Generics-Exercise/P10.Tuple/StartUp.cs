namespace P10.Tuple
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] inputArgs = Console.ReadLine().Split();
            string fullname = $"{inputArgs[0]} {inputArgs[1]}";
            Tuple<string, string> firstTuple = new Tuple<string, string>(fullname, inputArgs[2]);           

            inputArgs = Console.ReadLine().Split();
            Tuple<string, int> secondTuple = new Tuple<string, int>(inputArgs[0], int.Parse(inputArgs[1]));

            inputArgs = Console.ReadLine().Split();
            Tuple<int, double> thirdTuple = new Tuple<int, double>(int.Parse(inputArgs[0]), double.Parse(inputArgs[1]));

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }

    }
}
