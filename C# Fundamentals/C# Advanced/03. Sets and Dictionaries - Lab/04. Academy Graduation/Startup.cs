namespace _04.Academy_Graduation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
	
    public class Startup
    {
        public static void Main()
        {
            int students = int.Parse(Console.ReadLine());
            SortedDictionary<string, double> studentRecord = new SortedDictionary<string, double>();

            for (int i = 0; i < students; i++)
            {
                string studentName = Console.ReadLine();

                string marksInput = Console.ReadLine();

                var studentMarks = marksInput.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();

              
                studentRecord[studentName] = studentMarks.Average();            
            }

            foreach (var pair in studentRecord)
            {
                Console.WriteLine($"{pair.Key} is graduated with {pair.Value}");
            }
        }
    }
}
