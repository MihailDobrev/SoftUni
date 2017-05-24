
namespace _1.Debit_Card_Number
{
    using System;
    using System.Collections.Generic;
    public class DebitCardNumber
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int fourthNumber = int.Parse(Console.ReadLine());

            List<string> numbers = new List<string>();

            numbers.Add(firstNumber.ToString("D4"));
            numbers.Add(secondNumber.ToString("D4"));
            numbers.Add(thirdNumber.ToString("D4"));
            numbers.Add(fourthNumber.ToString("D4"));

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
