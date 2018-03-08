namespace _06.BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    public class Startup
    {
        public static void Main()
        {
            Queue<IBirthDate> allWithBirthDays = ReadAll();
            Queue<IBirthDate> bornInYear = FindThoseBornInAYear(allWithBirthDays);
            PrintAllDetaineesId(bornInYear);
        }

        private static void PrintAllDetaineesId(Queue<IBirthDate> bornInYear)
        {
            while (bornInYear.Count > 0)
            {
                var detainee = bornInYear.Dequeue();
                Console.WriteLine(detainee.BirthDate);
            }
        }

        private static Queue<IBirthDate> FindThoseBornInAYear(Queue<IBirthDate> allWithBirthDays)
        {
            Queue<IBirthDate> bornInYear
                = new Queue<IBirthDate>();

            string year = Console.ReadLine();

            while (allWithBirthDays.Count > 0)
            {
                var someOneWithBirthDate = allWithBirthDays.Dequeue();

                if (someOneWithBirthDate.BirthDate.EndsWith(year))
                {
                    bornInYear.Enqueue(someOneWithBirthDate);
                }
            }

            return bornInYear;
        }

        private static Queue<IBirthDate> ReadAll()
        {
            Queue<IBirthDate> allWithBirthdays = new Queue<IBirthDate>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] personalInfo = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (personalInfo[0])
                {
                    case "Citizen":
                        allWithBirthdays.Enqueue(new Citizen(personalInfo[1], int.Parse(personalInfo[2]), personalInfo[3], personalInfo[4]));
                        break;
                    case "Pet":
                        allWithBirthdays.Enqueue(new Pet(personalInfo[1], personalInfo[2]));
                        break;
                    default:
                        continue;
                }
            }

            return allWithBirthdays;
        }
    }
}
