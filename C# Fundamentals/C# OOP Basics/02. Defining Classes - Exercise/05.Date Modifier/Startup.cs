namespace _05.Date_Modifier
{
    using System;
    public class Startup
    {
        public static void Main()
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
            DateModifier dm = new DateModifier();
            double timeDifference = dm.CalculatesTimeDifference(firstDate, secondDate);
            Console.WriteLine(timeDifference);
        }
    }
}
