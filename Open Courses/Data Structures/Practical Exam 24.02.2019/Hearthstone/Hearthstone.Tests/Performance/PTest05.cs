using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class PTest05
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
    public void Remove_150_000_cards()
    {

        int initialCount = 150000;

        List<Card> cards = this.inputGenerator.GenerateCards(initialCount);

        Stopwatch stopwatch = new Stopwatch();


        foreach (Card card in cards)
        {
            this.board.Draw(card);
        }
        stopwatch.Start();
        foreach (Card card in cards)
        {
           this.board.Remove(card.Name);
        }

        stopwatch.Stop();

        long executionTimeInMillis = stopwatch.ElapsedMilliseconds;
        Assert.IsTrue(executionTimeInMillis <= 80);
        Assert.AreEqual(this.board.Count(), 0);

        ;
    }
}
