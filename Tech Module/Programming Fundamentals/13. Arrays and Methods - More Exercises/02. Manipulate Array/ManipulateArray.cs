

namespace _02.Manipulate_Array
{
    using System;
    using System.Linq;

    public class ManipulateArray
    {
        static void Main()
        {
            var strings = Console.ReadLine()
                .Split(' ')
                .Select(x => x)
                .ToArray();

            byte numberOfLines = Byte.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(x=>x).ToArray();
                switch (input[0])
                {
                    case "Distinct":
                        strings = strings.ToList().Select(x => x).Distinct().ToArray(); break;
                    case "Reverse":
                        strings = strings.ToList().Select(x => x).Reverse().ToArray(); break;
                    case "Replace":
                        strings[int.Parse(input[1])] = input[2]; break;
                    default:
                        break;
                }
               
            }
            Console.WriteLine(string.Join(", ", strings));
        }
    }
}
