namespace _05.Date_Modifier
{
    using System;

    public class DateModifier
    {
        public double CalculatesTimeDifference(string firstDateInput, string secondDateInput)
        {
            var firstDateArgs = firstDateInput.Split();
            Date firstDate = new Date(int.Parse(firstDateArgs[0]), int.Parse(firstDateArgs[1]), int.Parse(firstDateArgs[2]));

            var secondDateArgs = secondDateInput.Split();
            Date secondDate = new Date(int.Parse(secondDateArgs[0]), int.Parse(secondDateArgs[1]), int.Parse(secondDateArgs[2]));

            DateTime firstDateTime = new DateTime(firstDate.Year, firstDate.Month, firstDate.Day);
            DateTime secondDateTime = new DateTime(secondDate.Year, secondDate.Month, secondDate.Day);
            TimeSpan span = secondDateTime.Subtract(firstDateTime);
            return Math.Abs(span.TotalDays);
        }
    }
}
