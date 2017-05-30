
namespace _8.SMS_Typing
{
    using System;
    using System.Collections.Generic;

    public class SMSTyping
    {
        static void Main()
        {
            byte n = byte.Parse(Console.ReadLine());
            int letterAsNumber=0;
            List<char> message = new List<char>();

            for (byte i = 1; i <= n; i++)
            {
                string number = Console.ReadLine();

                int firstDigit = int.Parse(Convert.ToString(number[0]));

                if (firstDigit!=0)
                {
                    letterAsNumber = (firstDigit - 2) * 3 + number.Length - 1 + 97 + (number[0] >= '8' ? 1 : 0);
                }
                else
                {
                    letterAsNumber = 32;
                }
               

                message.Add(Convert.ToChar(letterAsNumber));
            }

            foreach (var letter in message)
            {
                Console.Write(letter);
            }
        }
    }
}
