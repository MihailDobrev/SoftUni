namespace _13.Magic_exchangeable_words
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string[] words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string firstWord = words[0];
            string secondWord = words[1];
            int firstWordLenght = firstWord.Length;
            int secondWordLenght = secondWord.Length;
            bool areExchangable = true;

            Dictionary<char, char> uniqueLetters = new Dictionary<char, char>();
            int shorterWordLenght = firstWordLenght <= secondWordLenght ? firstWordLenght : secondWordLenght;

            for (int index = 0; index < shorterWordLenght; index++)
            {
                if (!uniqueLetters.ContainsKey(firstWord[index]))
                {
                    
                    if (uniqueLetters.ContainsValue(secondWord[index]))
                    {
                        areExchangable = false;
                        break;
                    }
                    uniqueLetters[firstWord[index]] = secondWord[index];
                }
                else
                {
                    if (uniqueLetters[firstWord[index]] != secondWord[index])
                    {
                        areExchangable = false;
                        break;
                    }
                }
            }

            if (firstWordLenght != secondWordLenght)
            {
                int differenceInLenght = Math.Abs(firstWordLenght - secondWordLenght);

                string longerWord = firstWordLenght > secondWordLenght ? firstWord : secondWord;

                for (int index = longerWord.Length - differenceInLenght; index < longerWord.Length; index++)
                {
                    if (!uniqueLetters.ContainsValue(longerWord[index]) && !uniqueLetters.ContainsKey(longerWord[index]))
                    {
                        areExchangable = false;
                        break;
                    }
                }
            }

            Console.WriteLine(areExchangable.ToString().ToLower());

        }
    }
}
