
namespace Problem_2.Add_Two_Numbers
{
    using System;
    public class AddTwoNumbers
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            Console.WriteLine($"{a} + {b} = {a + b}");
        }
    }
}
