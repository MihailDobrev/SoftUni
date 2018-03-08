namespace _05.BorderControl
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            Queue<IIdentifiable> allPassingTheBorder = ReadAll();
            Queue<IIdentifiable> detainees = FindDetainees(allPassingTheBorder);
            PrintAllDetaineesId(detainees);
        }

        private static void PrintAllDetaineesId(Queue<IIdentifiable> detainees)
        {
            while (detainees.Count>0)
            {
                var detainee = detainees.Dequeue();
                Console.WriteLine(detainee.Id);
            }         
        }

        private static Queue<IIdentifiable> FindDetainees(Queue<IIdentifiable> allPassingTheBorder)
        {
            Queue<IIdentifiable> allDetained
                = new Queue<IIdentifiable>();

            string forbiddenId = Console.ReadLine();

            while (allPassingTheBorder.Count>0)
            {
                IIdentifiable someOnePassingTheBorder = allPassingTheBorder.Dequeue();

                if (someOnePassingTheBorder.Id.EndsWith(forbiddenId))
                {
                    allDetained.Enqueue(someOnePassingTheBorder);
                }
            }

            return allDetained;
        }

        private static Queue<IIdentifiable> ReadAll()
        {
            Queue<IIdentifiable> detainees = new Queue<IIdentifiable>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] personalInfo = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (personalInfo.Length == 2)
                {
                    detainees.Enqueue(new Robot(personalInfo[0], personalInfo[1]));
                }
                else if (personalInfo.Length == 3)
                {
                    detainees.Enqueue(new Citizen(personalInfo[0], int.Parse(personalInfo[1]), personalInfo[2]));
                }
            }

            return detainees;
        }
    }
}
