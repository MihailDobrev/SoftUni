namespace _06.Count_Substring_Occurrences
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string searchText = Console.ReadLine();
            string searchedText = Console.ReadLine();
            int searchedTextLenght = searchedText.Length;

            int matchCounter = 0;

            for (int index = 0; index <= searchText.Length - searchedTextLenght; index++)
            {
                string search = searchText.Substring(index, searchedTextLenght).ToLower();

                if (search==searchedText.ToLower())
                {
                    matchCounter++;
                }
            }
            Console.WriteLine(matchCounter);
        }
    }
}
