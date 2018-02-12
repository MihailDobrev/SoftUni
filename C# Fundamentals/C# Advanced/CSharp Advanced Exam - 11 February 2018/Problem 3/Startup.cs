namespace Problem_3
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < numberOfRows; row++)
            {
                sb.Append(Console.ReadLine());
            }

            string cryptoBlockchain = sb.ToString();
            sb.Clear();

            string pattern = @"((?<hash>{)|\[)[^{\[]*?(?<digits>[0-9]{3,})[^{\[]*?(?(hash)}|])";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(cryptoBlockchain);

            Queue<int> numbers = new Queue<int>();
            StringBuilder decryptedText = new StringBuilder();

            foreach (Match match in matches)
            {
                string searchedNumberAsText = match.Groups["digits"].Value;

                if (searchedNumberAsText.Length%3==0)
                {
                    for (int index = 0; index < searchedNumberAsText.Length; index+=3)
                    {
                        sb.Append(searchedNumberAsText[index]);
                        sb.Append(searchedNumberAsText[index+1]);
                        sb.Append(searchedNumberAsText[index+2]);
                        numbers.Enqueue(int.Parse(sb.ToString()));
                        sb.Clear();
                    }

                    int blockSize = match.Groups[0].Value.Length;

                    while (numbers.Count > 0)
                    {
                        int substractedASCIcode = numbers.Dequeue() - blockSize;

                        char letter = (char)substractedASCIcode;
                        decryptedText.Append(letter);
                    }
                }
            }

            Console.WriteLine(decryptedText.ToString());
         
        }
    }
}
