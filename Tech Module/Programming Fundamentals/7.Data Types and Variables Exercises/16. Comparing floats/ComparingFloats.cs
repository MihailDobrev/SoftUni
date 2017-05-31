
namespace _16.Comparing_floats
{
    using System;

    public class ComparingFloats
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            bool equal = true;

            if (Math.Abs(a-b)>=0.000001)
            {
                equal = false;
            }
            Console.WriteLine(equal);
        }
    }
}
