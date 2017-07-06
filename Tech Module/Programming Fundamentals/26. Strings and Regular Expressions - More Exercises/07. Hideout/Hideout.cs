namespace _07.Hideout
{
    using System;
    public class Hideout
    {
        static void Main()
        {
            string map = Console.ReadLine();
            int index = 0;
            int lastIndex = 0;
            bool hideoutFound = false;

            for (int i = 1; i <= 3; i++)
            {
                string[] searchedChars = Console.ReadLine().Split();
                string hideoutMarker = searchedChars[0];
                int minimumAmountOfChars = int.Parse(searchedChars[1]);
                string pattern = new string(char.Parse(hideoutMarker), minimumAmountOfChars);

                if (map.Contains(pattern))
                {

                    hideoutFound = true;
                    index = map.IndexOf(pattern);

                    for (int j = index; j < map.Length; j++)
                    {
                        if (map[j] == char.Parse(hideoutMarker))
                        {
                            lastIndex++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (hideoutFound)
                {
                    break;
                }
            }

            if (hideoutFound)
            {
                Console.WriteLine($"Hideout found at index {index} and it is with size {lastIndex}!");
            }

        }
    }
}
