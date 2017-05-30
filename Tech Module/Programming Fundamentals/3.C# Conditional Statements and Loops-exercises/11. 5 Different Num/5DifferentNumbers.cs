namespace _11._5_Different_Num
{
    using System;
    public class _5DifferentNumbers
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            int difference = b - a;

            if (difference<5)
            {
                Console.WriteLine("No");
            }
            else
            {
                for (int firstRow = a; firstRow <= b - 4; firstRow++)
                {
                    for (int secondRow = a + 1; secondRow <= b - 3; secondRow++)
                    {
                        for (int thirdRow = a + 2; thirdRow <= b - 2; thirdRow++)
                        {
                            for (int fourthRow = a + 3; fourthRow <= b - 1; fourthRow++)
                            {
                                for (int fifthRow = a + 4; fifthRow <= b; fifthRow++)
                                {
                                    if (firstRow < secondRow &&
                                        secondRow < thirdRow &&
                                        thirdRow < fourthRow &&
                                        fourthRow < fifthRow)
                                    {
                                        Console.WriteLine($"{firstRow} {secondRow} {thirdRow} {fourthRow} {fifthRow}");
                                    }

                                }

                            }

                        }

                    }

                }
            }

            
        }
    }
}
