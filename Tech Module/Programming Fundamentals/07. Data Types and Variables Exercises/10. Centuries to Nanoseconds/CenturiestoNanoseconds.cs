
namespace _10.Centuries_to_Nanoseconds
{
    using System;
    using System.Numerics;
    public class CenturiestoNanoseconds
    {
        static void Main()
        {
            byte centuries = byte.Parse(Console.ReadLine());
            int years = centuries * 100;
            int days = (int)(365.2422 * years);
            long hours = 24 * days;
            long minutes = 60 * hours;
            BigInteger seconds = 60 * minutes;
            BigInteger milleseconds = seconds * 1000;
            BigInteger microseconds = milleseconds * 1000;
            BigInteger nanoseconds = microseconds * 1000;
            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milleseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
        }
    }
}
