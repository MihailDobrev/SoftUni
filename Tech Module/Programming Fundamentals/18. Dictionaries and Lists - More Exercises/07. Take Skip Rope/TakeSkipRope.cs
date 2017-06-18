

namespace _07.Take_Skip_Rope
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class TakeSkipRope
    {
        static void Main()
        {
            var input = Console.ReadLine();
            List<int> numberList = new List<int>();
            List<char> text = new List<char>();

            foreach (var symbol in input)
            {
                int number;
                bool isNumber = int.TryParse(symbol.ToString(), out number);
                if (isNumber)
                {
                    numberList.Add(number);
                }
                else
                {
                    text.Add(symbol);
                }
            }

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            for (int i = 0; i < numberList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numberList[i]);
                }
                else
                {
                    skipList.Add(numberList[i]);
                }
               
            }

            int total = 0;
            List<char> takenText = new List<char>();
            List<char> resultList = new List<char>();

            for (int i = 0; i < skipList.Count; i++)
            {
                takenText = text
                    .Skip(total)
                    .Take(takeList[i])
                    .ToList();
                total +=skipList[i]+takeList[i];
                resultList.AddRange(takenText);
            }

            Console.WriteLine(string.Join("",resultList));
        }
    }
}
