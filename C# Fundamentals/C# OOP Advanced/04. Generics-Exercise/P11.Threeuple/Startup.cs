namespace P11.Threeuple
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string[] inputArgs = Console.ReadLine().Split();
            string fullname = $"{inputArgs[0]} {inputArgs[1]}";
            Threeuple<string, string, string> firstTuple = new Threeuple<string, string, string>(fullname, inputArgs[2], inputArgs[3]);

            inputArgs = Console.ReadLine().Split();
            Threeuple<string, int, bool> secondTuple = new Threeuple<string, int, bool>(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2] == "drunk" ? true : false);

            inputArgs = Console.ReadLine().Split();
            Threeuple<string, double, string> thirdTuple = new Threeuple<string, double, string>(inputArgs[0], double.Parse(inputArgs[1]), inputArgs[2]);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
