using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class PTest07
{
    protected Board board;
    protected InputGenerator inputGenerator;

    protected class InputGenerator
    {


        private int[] damage = { 3, 4, 5, 6, 7, 8, 10, 9 };

        private int[] scores = { 7, 15, 6, 9, 12, 3, 8 };

        private int[] level = { 1, 2, 3, 4, 5 };
        public List<Card> GenerateCards(int count)
        {
            var names = GenerateNames(count);
            List<Card> competitors = new List<Card>();
            for (int i = 1; i <= count; i++)
            {

                competitors.Add(new Card(names[i % names.Count], damage[i % damage.Length], scores[i % scores.Length], level[i % level.Length]));
            }
            return competitors;
        }

        public List<string> GenerateNames(int count)
        {

            var list = new List<string>();
            for (int i = 0; i < count; i++)
            {
                list.Add(string.Format(@"{0} card", Guid.NewGuid()));
            }

            return list;
        }

    }
    [SetUp]
    public void Init()
    {
        this.board = new Board();
        this.inputGenerator = new InputGenerator();
    }
    [TestCase]
    public void Play_250_000_card_get_best_of_range()
    {

        int initialCount = 250000;

        List<Card> cards = this.inputGenerator.GenerateCards(initialCount);


        foreach (Card card in cards)
        {
            this.board.Draw(card);
        }

        for (int i = 0; i < cards.Count / 2; i++)
        {
            Card first = cards[i];
            Card second = cards[cards.Count - i - 1];
            if (first.Level == second.Level)
            {
                this.board.Play(first.Name, second.Name);
            }
        }

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        this.board.GetBestInRange(0, int.MaxValue);
        stopwatch.Stop();
        long executionTimeInMillis = stopwatch.ElapsedMilliseconds;
        Assert.IsTrue(executionTimeInMillis <= 110);
    }
}
