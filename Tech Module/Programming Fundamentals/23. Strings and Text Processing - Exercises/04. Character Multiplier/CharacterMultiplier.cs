namespace _04.Character_Multiplier
{
    using System;
    public class CharacterMultiplier
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();
            int sum = 0;
            string firstWord = input[0];
            string secondWord = input[1];
            string shorterWord = firstWord.Length < secondWord.Length ? firstWord : secondWord;
            string longerWord = firstWord.Length > secondWord.Length ? firstWord : secondWord;

            for (int i = 0; i < shorterWord.Length; i++)
            {
                int firstAsciCode = firstWord[i];
                int secondAsciCode = secondWord[i];
                sum += firstAsciCode * secondAsciCode;
            }

            for (int i = shorterWord.Length; i < longerWord.Length; i++)
            {
                int AsciCode = longerWord[i];
                sum += AsciCode;
            }
            Console.WriteLine(sum);

        }
    }
}
