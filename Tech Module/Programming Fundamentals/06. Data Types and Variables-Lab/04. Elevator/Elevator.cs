namespace _04.Elevator
{
    using System;
    public class Elevator
    {
        static void Main()
        {
            int people = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int Courses = (int)Math.Ceiling((double)people / capacity);
            Console.WriteLine(Courses);
        }
    }
}
