
namespace Objects_and_Class
{
    using System;
    using System.Linq;
    public class CountWorkingDays
    {
        static void Main()
        {
            var startDateInput = Console.ReadLine()
                .Split('-')
                .Select(int.Parse)
                .ToArray();

            var endDateInput = Console.ReadLine()
            .Split('-')
            .Select(int.Parse)
            .ToArray();

            var holidays = new DateTime[]
            {
                new DateTime (04,01,01),
                new DateTime (04,03,03),
                new DateTime (04,05,01),
                new DateTime (04,05,06),
                new DateTime (04,05,24),
                new DateTime (04,09,06),
                new DateTime (04,09,22),
                new DateTime (04,11,01),
                new DateTime (04,12,24),
                new DateTime (04,12,25),
                new DateTime (04,12,26),
            };

            int workingDayCounter = 0;
            
            DateTime startDate = new DateTime(startDateInput[2], startDateInput[1], startDateInput[0]);
            DateTime endDate = new DateTime(endDateInput[2], endDateInput[1], endDateInput[0]);

            for (DateTime i = startDate; i <= endDate; i = i.AddDays(1))
            {
                DayOfWeek day = i.DayOfWeek;
                DateTime temp = new DateTime(4, i.Month, i.Day);

                if (!holidays.Contains(temp) && (!day.Equals(DayOfWeek.Saturday) && !day.Equals(DayOfWeek.Sunday)))
                {
                    workingDayCounter++;
                }
            }
            Console.WriteLine(workingDayCounter);
        }
    }
}
