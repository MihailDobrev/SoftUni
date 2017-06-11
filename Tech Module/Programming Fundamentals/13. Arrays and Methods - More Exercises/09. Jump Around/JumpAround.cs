namespace _09.Jump_Around
{
    using System;
    using System.Linq;

    public class JumpAround
    {
        static void Main()
        {
            var integerArray = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int lenght = integerArray[0];
            int newIndex = 0;
            int sum = integerArray[0];

            while (newIndex + lenght < integerArray.Length || newIndex - lenght >= 0)
            {
                if (newIndex + lenght < integerArray.Length)
                {
                    newIndex = newIndex + lenght;
                    
                }
                else if(newIndex - lenght >= 0)
                {
                    newIndex = newIndex - lenght;
                }

                lenght = integerArray[newIndex];
                sum += lenght;

            }
            Console.WriteLine(sum);
        }
    }
}
