namespace _03
{
    using System;
    using System.Text.RegularExpressions;


    public class ThirdProblem
    {
        static void Main()
        {
            string inputLine = Console.ReadLine();
            string didimonPattern = @"([^a-zA-Z-]+)";
            string bojomonPattern = @"([a-zA-Z]+-[a-zA-Z]+)";

            while (true)
            {
                var didimonMatch = Regex.Match(inputLine, didimonPattern);

                if (didimonMatch.Success)
                {
                    string didimonFirstMatch = didimonMatch.Value;
                    Console.WriteLine(didimonFirstMatch);
                    inputLine = inputLine.Substring(didimonMatch.Index + didimonFirstMatch.Length);
                    var bojomonMatch = Regex.Match(inputLine, bojomonPattern);

                    if (bojomonMatch.Success)
                    {
                        string bojomonFirstMatch = bojomonMatch.Value;
                        Console.WriteLine(bojomonFirstMatch);
                        inputLine = inputLine.Substring(bojomonMatch.Index + bojomonFirstMatch.Length);

                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }

            }
        }
    }
}
