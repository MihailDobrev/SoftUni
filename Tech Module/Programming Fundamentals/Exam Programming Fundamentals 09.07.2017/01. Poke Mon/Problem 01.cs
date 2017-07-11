namespace _01
{
    using System;

    public class FirstProblem
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int initalNValue = n;
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int targetsPoked = 0;

            while (n >= m)
            {
                n -= m;
                targetsPoked++;
                if (n * 2 == initalNValue && y!=0)
                {  
                    if (n / y > 0)
                    {
                        n /= y;
                    }
                    else
                    {
                        continue;
                    }
                }

            }
            Console.WriteLine(n);
            Console.WriteLine(targetsPoked);
        }
    }
}
