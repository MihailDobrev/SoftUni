namespace P01.Generic_Box_of_String
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int numberOfStrings = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfStrings; i++)
            {
                string content = Console.ReadLine();
                bool isNumber = int.TryParse(content, out int number);

                if (isNumber)
                {
                    Box<int> box = new Box<int>(number);
                    Console.WriteLine(box);
                }
                else
                {
                    Box<string> box = new Box<string>(content);
                    Console.WriteLine(box);
                }
            }

        }

    }
}
