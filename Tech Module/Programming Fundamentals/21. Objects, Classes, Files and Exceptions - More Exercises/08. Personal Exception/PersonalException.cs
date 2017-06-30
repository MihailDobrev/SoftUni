namespace _08.Personal_Exception
{
    using System;
    class PersonalException
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            while (true)
            {
                if (number < 0)
                {
                    try
                    {
                        throw new NegativeNumberException();
                    }
                    catch (NegativeNumberException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                }
                else
                {
                    Console.WriteLine(number);
                }

                number = int.Parse(Console.ReadLine());
            }
        }
    }
}
