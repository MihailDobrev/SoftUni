namespace Problem_1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bulletSequence = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] lockSequence = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int intelligenceValue = int.Parse(Console.ReadLine());

            Queue<int> bullets = new Queue<int>();

            for (int index = bulletSequence.Length - 1; index >= 0; index--)
            {
                bullets.Enqueue(bulletSequence[index]);
            }

            Queue<int> locks = new Queue<int>();

            foreach (var currentLock in lockSequence)
            {
                locks.Enqueue(currentLock);
            }

            int shotsFiredInClip = 0;
            int totalBulletsFired = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {

                int bullet = bullets.Dequeue();
                int lockToUnlock = locks.Peek();

                if (bullet <= lockToUnlock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                shotsFiredInClip++;
                totalBulletsFired++;

                if (shotsFiredInClip == gunBarrelSize && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    shotsFiredInClip = 0;
                }

            }

            if (locks.Count == 0)
            {
                int bulletCosts = bulletPrice * totalBulletsFired;
                int moneyEarned = intelligenceValue - bulletCosts;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
            else if (bullets.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }

        }
    }
}
