
namespace _10.Multiplication_Table_2._0
{
    using System;
    public class MultiplicationTable
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());

            if (multiplier<=10)
            {
                for (int i = multiplier; i <= 10; i++)
                {
                    Console.WriteLine($"{number} X {multiplier} = {number * multiplier}");
                    multiplier++;
                }
            }
            else if(multiplier>10)
            {
                Console.WriteLine($"{number} X {multiplier} = {number * multiplier}");
            }
            
        }
    }
}
