namespace P08.Custom_List_Sorter
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            CommandInterpreneur commandInterpreneur = new CommandInterpreneur();
            string output = commandInterpreneur.GenerateOutput();
            PrintOutput(output);
        }

        private static void PrintOutput(string output)
        {
            Console.WriteLine(output);
        }
    }
}
