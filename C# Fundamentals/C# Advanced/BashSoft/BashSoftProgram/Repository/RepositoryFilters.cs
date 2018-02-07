namespace BashSoftProgram
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RepositoryFilters
    {
        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int studentsToTake)
        {
            wantedFilter = wantedFilter.ToLower();

            if (wantedFilter == "excellent")
            {
                FilterAndTake(wantedData, X => X >= 5, studentsToTake);
            }
            else if (wantedFilter == "average")
            {
                FilterAndTake(wantedData, x => x < 5 && x >= 3.5, studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                FilterAndTake(wantedData, x => x < 3.5, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentsFilter);
            }
        }

        private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter, int studentsToTake)
        {
            int counterForPrinted = 0;
            foreach (var userName_Points in wantedData)
            {
                if (counterForPrinted == studentsToTake)
                {
                    break;
                }
                //double averageMark = Average(userName_Points.Value);
                double averageScore = userName_Points.Value.Average();
                double percentageOfFullfillment = averageScore / 100;
                double mark = percentageOfFullfillment * 4 + 2;
                if (givenFilter(mark))
                {
                    OutputWriter.PrintStudent(userName_Points);
                    counterForPrinted++;
                }
            }
        }

        //Removed block of code after using LINQ

        //private static bool ExcellentFilter(double mark)
        //{
        //    return mark >= 5;
        //}
        //private static bool AverageFilter(double mark)
        //{
        //    return mark < 5.0 && mark >= 3.5;
        //}

        //private static bool PoorFilter(double mark)
        //{
        //    return mark < 3.5;
        //}

        //private static double Average(List<int> scoresOnTasks)
        //{
        //    int totalScore = 0;

        //    foreach (var score in scoresOnTasks)
        //    {
        //        totalScore += score;
        //    }

        //    var percentageOfAll = totalScore / (scoresOnTasks.Count * 100.0);
        //    var mark = percentageOfAll * 4 + 2;

        //    return mark;
        //}
    }
}
