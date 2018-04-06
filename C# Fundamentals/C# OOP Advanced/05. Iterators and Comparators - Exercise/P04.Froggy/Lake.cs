
namespace P04.Froggy
{
    using System.Collections;
    using System.Collections.Generic;

    public class Lake<T> : IEnumerable<T>
    {
        private List<T> stones;

        public Lake(params T[] stones)
        {
            this.stones = new List<T>(stones);
        }
        public IEnumerator<T> GetEnumerator()
        {

            for (int index = 0; index < stones.Count; index += 2)
            {
                yield return stones[index];
            }
            int totalStones = stones.Count;
            int startingIndex = totalStones % 2 == 0 ? totalStones - 1 : totalStones - 2;

            for (int index = startingIndex; index >= 0; index -= 2)
            {
                yield return stones[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
