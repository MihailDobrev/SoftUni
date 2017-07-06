

namespace _05.Only_Letters
{
    using System;

    public class OnlyLetters
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string returned = "";
            int result = 0;
            bool endWithNumbers = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetter(input[i]))
                {
                    returned += input[i];
                }
                else if (Char.IsDigit(input[i]))
                {

                    for (int j = i; j < input.Length; j++)
                    {
                        endWithNumbers = int.TryParse(input.Substring(i), out result);
                        if (endWithNumbers)
                        {
                            returned += input.Substring(i);
                            break;
                        }
                        else if (Char.IsLetter(input[j]))
                        {
                            returned += input[j];
                            i = j - 1;
                            break;
                        }
                    }

                }
                if (endWithNumbers)
                {
                    break;
                }
            }
            Console.WriteLine(returned);
        }
    }
}
