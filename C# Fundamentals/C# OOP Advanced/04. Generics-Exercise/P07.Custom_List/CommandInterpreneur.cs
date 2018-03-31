namespace P07.Custom_List
{
    using System;
    using System.Text;

    public class CommandInterpreneur
    {
        private CustomList<string> customList;
        public CommandInterpreneur()
        {
            customList = new CustomList<string>();
        }
        public string GenerateOutput()
        {
            string input;
            StringBuilder sb = new StringBuilder();

            while ((input=Console.ReadLine())!="END")
            {
                string[] args = input.Split();
                string commandName = args[0];
                switch (commandName)
                {
                    case "Add":
                        customList.Add(args[1]);
                        break;
                    case "Remove":
                        customList.Remove(int.Parse(args[1]));
                        break;                
                    case "Contains":
                        sb.AppendLine(customList.Contains(args[1]).ToString());
                        break;
                    case "Swap":
                        customList.Swap(int.Parse(args[1]), int.Parse(args[2]));
                        break;
                    case "Greater":
                        sb.AppendLine(customList.CountGreaterThan(args[1]).ToString());
                        break;
                    case "Max":
                        sb.AppendLine(customList.Max());
                        break;
                    case "Min":
                        sb.AppendLine(customList.Min());
                        break;
                    case "Print":
                        sb.AppendLine(string.Join(Environment.NewLine, customList.Data));
                        break;
                    default:
                        break;
                }
            }

            return sb.ToString();
        }
    }
}