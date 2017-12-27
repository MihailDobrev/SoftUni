namespace _12.Inferno_III
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();
            numbers.Insert(0, 0);
            numbers.Insert(numbers.Count, 0);
            List<string> finalCommands = new List<string>();
            string filterType = string.Empty;
            int parameter = 0;

             string inputLine = Console.ReadLine();

            while (!inputLine.Equals("Forge"))
            {
                string[] commandData = inputLine.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                string commandType = commandData[0];
                filterType = commandData[1];
                parameter = int.Parse(commandData[2]);
                string command = filterType +';'+ parameter;

                if (commandType == "Exclude")
                {
                    finalCommands.Add(command);
                }
                else if(commandType == "Reverse")
                {
                    finalCommands.Remove(command);
                }

                inputLine = Console.ReadLine();
            }

            foreach (string command in finalCommands)
            {
                string[] commandData = command.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                filterType = commandData[0];
                parameter = int.Parse(commandData[1]);

                switch (filterType)
                {
                    case "Sum Left":
                        for (int index = 1; index < numbers.Count; index++)
                        {
                            if (numbers[index]+numbers[index-1]==parameter)
                            {
                                numbers.RemoveAt(index);
                            }
                        }
                        break;
                    case "Sum Right":
                        for (int index = 0; index < numbers.Count-1; index++)
                        {
                            if (numbers[index] + numbers[index + 1] == parameter)
                            {
                                numbers.RemoveAt(index);
                            }
                        }
                        break;

                    case "Sum Left Right":
                        for (int index = 1; index < numbers.Count - 1; index++)
                        {
                            if (numbers[index] + numbers[index - 1] + numbers[index + 1] == parameter)
                            {
                                numbers.RemoveAt(index);
                            }
                        }
                        break;
                    default:
                        break;
                }
       
            }

            numbers.RemoveAt(0);
            numbers.RemoveAt(numbers.Count - 1);

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
