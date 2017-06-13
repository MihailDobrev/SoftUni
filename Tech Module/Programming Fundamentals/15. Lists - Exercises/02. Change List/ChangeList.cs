
namespace _02.Change_List
{
    using System;
    using System.Linq;

    public class ChangeList
    {
        static void Main()
        {
            var integerList = Console.ReadLine()
               .Split(' ')
               .Select(int.Parse)
               .ToList();
            string input = Console.ReadLine();

            while (input != "Odd" && input != "Even")
            {
                var command = input.Split(' ');
                switch (command[0])
                {
                    case "Delete":
                        integerList.RemoveAll(x => x == int.Parse(command[1])); break;
                    case "Insert":
                        integerList.Insert(int.Parse(command[2]), int.Parse(command[1])); break;
                    default: break;
                }
                input = Console.ReadLine();
            }

            if (input == "Odd")
            {
                integerList
                    .Where(x => x % 2 == 1)
                    .ToList()
                    .ForEach(x => Console.Write(x + " "));
            }
            else if (input == "Even")
            {
                integerList
                    .Where(x => x % 2 == 0)
                    .ToList()
                    .ForEach(x => Console.Write(x + " "));
            }
        }
    }
}
