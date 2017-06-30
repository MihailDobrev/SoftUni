namespace _07.Play_Catch
{
    using System;
    using System.Linq;
    public class PlayCatch
    {
        static void Main()
        {
            var nums = Console.ReadLine().Split()
                 .Select(int.Parse).ToList();

            var exepCount = 0;

            while (exepCount < 3)
            {
                var input = Console.ReadLine().Split();
                var command = input[0];
                try
                {
                    if (command == "Replace")
                    {
                        var index = int.Parse(input[1]);
                        nums[index] = int.Parse(input[2]);
                    }
                    else if (command == "Print")
                    {
                        var index = int.Parse(input[1]);
                        var endIndex = int.Parse(input[2]);
                        Console.WriteLine
                           (string.Join(", ", nums.GetRange(index, endIndex - index + 1)));
                    }
                    else if (command == "Show")
                    {
                        var index = int.Parse(input[1]);
                        Console.WriteLine(nums[index]);
                    }
                }
                catch
                {
                    if (input.Length > 2)
                    {
                        var check = 0;
                        if (int.TryParse(input[1], out check) &&
                            int.TryParse(input[2], out check))
                        {
                            Console.WriteLine("The index does not exist!");
                        }
                        else
                            Console.WriteLine("The variable is not in the correct format!");
                    }
                    else
                    {
                        var check = 0;
                        if (int.TryParse(input[1], out check))
                        {
                            Console.WriteLine("The index does not exist!");
                        }
                        else
                            Console.WriteLine("The variable is not in the correct format!");
                    }
                    exepCount++;
                }
            }
            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
