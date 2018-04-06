namespace P04.Froggy
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] stones = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Lake<int> lake = new Lake<int>(stones);
            Console.WriteLine(string.Join(", ",lake.ToArray()));
        }
    }
}
