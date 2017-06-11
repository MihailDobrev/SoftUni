
namespace _03.Safe_Manipulation
{
    using System;
    using System.Linq;
    public class SafeManipulation
    {
        static void Main()
        {
            var strings = Console.ReadLine()
                   .Split(' ')
                   .Select(x => x)
                   .ToArray();
            string command=Console.ReadLine();

            while (command != "END")
            {
                var input = command.Split(' ').Select(x => x).ToArray();
                command = input[0];


                switch (command)
                {
                    case "Distinct":
                        strings = strings.Distinct().ToArray(); break;
                    case "Reverse":
                        strings = strings.Reverse().ToArray(); break;
                    case "Replace":
                        int index = int.Parse(input[1]);
                        if (index < strings.Length && index >= 0)
                        {
                            strings[index] = input[2];
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
                command = Console.ReadLine();
            } 

            Console.WriteLine(string.Join(", ", strings));
        }
}
}
