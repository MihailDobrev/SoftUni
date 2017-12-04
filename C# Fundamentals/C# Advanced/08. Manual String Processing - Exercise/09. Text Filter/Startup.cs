namespace _09.Text_Filter
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string[] bannedWords = Console.ReadLine().Split(new char[] {' ',','},StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            for (int bannedWordsIndex = 0; bannedWordsIndex < bannedWords.Length; bannedWordsIndex++)
            {
                int bannedWordLenght = bannedWords[bannedWordsIndex].Length;
                for (int textIndex = 0; textIndex <= text.Length- bannedWordLenght; textIndex++)
                {
                    string wordToReplace = bannedWords[bannedWordsIndex];
                    if (wordToReplace == text.Substring(textIndex, bannedWordLenght))
                    {
                        text = text.Replace(wordToReplace, new string('*', bannedWordLenght));
                    }
                }
            }

            Console.WriteLine(text);
        }
    }
}
