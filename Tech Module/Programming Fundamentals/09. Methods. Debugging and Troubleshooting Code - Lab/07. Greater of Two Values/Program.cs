
namespace Greater_of_Two_Values
{
    using System;

    public class GreaterOfTwoValues
    {
        static void Main()
        {
            string inputType = Console.ReadLine();
            var firstInput = Console.ReadLine();
            var secondInput = Console.ReadLine();
            var returnedMaxInput = GetMax(inputType, firstInput, secondInput);
            Console.WriteLine(returnedMaxInput);
        }

        private static string GetMax(string inputType, string firstInput, string secondInput)
        {
            if (inputType == "int")
            {
                if (Convert.ToInt32(firstInput) >= Convert.ToInt32(secondInput))
                {
                    return firstInput;
                }
                else
                {
                    return secondInput;
                }
            }
            else if (inputType == "char")
            {
                if (Convert.ToChar(firstInput) >= Convert.ToChar(secondInput))
                {
                    return firstInput;
                }
                else
                {
                    return secondInput;
                }
            }
            else
            {
                if (firstInput.CompareTo(secondInput) >= 0)
                {
                    return firstInput;
                }
                else
                {
                    return secondInput;
                }
            }

        }

    }
}
