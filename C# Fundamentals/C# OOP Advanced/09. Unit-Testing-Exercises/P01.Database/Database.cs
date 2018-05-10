namespace P01.Database
{
    using System;
    using System.Linq;
    public class Database
    {
        private const int maxCapacity = 16;
        private int[] numbers;


        public Database(int[] numbers)
        {
            Numbers = numbers;
        }

        public int[] Numbers
        {
            get { return numbers; }
            private set
            {
                if (value.Length > maxCapacity)
                {
                    throw new InvalidOperationException();
                }
                numbers = new int[maxCapacity];
                Array.Copy(value, Numbers, value.Length);
            }
        }


        public void Add(int numberToAdd)
        {

            if (Numbers.Any(n => n == 0))
            {
                int firstFreeElementIndex = Array.IndexOf(numbers,numbers.First(n => n == 0));
                numbers[firstFreeElementIndex] = numberToAdd;
            }
            else
            {
                throw new InvalidOperationException();
            }

        }

        public void Remove()
        {
            if (numbers.Any(n => n != 0))
            {
                int firstElementToRemove = Array.IndexOf(numbers, numbers.Last(n => n != 0));
                numbers[firstElementToRemove] = 0;

            }
            else
            {
                throw new InvalidOperationException();
            }

        }
        public int[] Fetch()
        {
            return this.Numbers;
        }
    }
}
