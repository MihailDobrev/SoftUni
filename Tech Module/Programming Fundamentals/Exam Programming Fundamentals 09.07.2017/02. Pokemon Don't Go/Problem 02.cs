namespace _02
{
    using System;
    using System.Linq;


    public class SecondProblem
    {
        static void Main()
        {
            var integerSequence = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sumOfAllRemovedElements = 0;

            while (true)
            {
                int indexToRemove = int.Parse(Console.ReadLine());
                int elementAtIndexToRemove = 0;

                if (indexToRemove>=0 && indexToRemove<integerSequence.Count)
                {
                    elementAtIndexToRemove = integerSequence[indexToRemove];
                    sumOfAllRemovedElements += elementAtIndexToRemove;
                    integerSequence.RemoveAt(indexToRemove);
                }
                else if (indexToRemove<0)
                {
                    elementAtIndexToRemove = integerSequence[0];
                    sumOfAllRemovedElements += elementAtIndexToRemove;
                    integerSequence[0] = integerSequence[integerSequence.Count - 1];
                }
                else if (indexToRemove >= integerSequence.Count)
                {
                    elementAtIndexToRemove = integerSequence[integerSequence.Count - 1];
                    sumOfAllRemovedElements += elementAtIndexToRemove;
                    integerSequence[integerSequence.Count - 1] = integerSequence[0];
                }
                if (integerSequence.Count==0)
                {
                    break;
                }
                else
                {
                    for (int i = 0; i < integerSequence.Count; i++)
                    {
                        if (integerSequence[i] > elementAtIndexToRemove)
                        {
                            integerSequence[i] -= elementAtIndexToRemove;
                        }
                        else if (integerSequence[i] <= elementAtIndexToRemove)
                        {
                            integerSequence[i] += elementAtIndexToRemove;
                        }
                    }
                }  
            }
            Console.WriteLine(sumOfAllRemovedElements);
        }
    }
}
