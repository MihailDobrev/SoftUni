namespace _5.Hands_of_Cards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HandsOfCards
    {
        static void Main()
        {
            var cardPowers = GetCardPowers();
            var cardTypes = GetCardTypes();
            var cards = new Dictionary<string, HashSet<int>>();

            string line = Console.ReadLine();
            while (line != "JOKER")
            {
                var tokens = line.Split(':');
                var name = tokens[0];
                var playerCards = tokens[1].Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                foreach (var card in playerCards)
                {
                    var cardPower = card.Substring(0, card.Length - 1);
                    var cardType = card.Substring(card.Length - 1).ToString();

                    var sum = cardPowers[cardPower] * cardTypes[cardType];

                    if (!cards.ContainsKey(name))
                    {
                        cards[name] = new HashSet<int>();
                    }

                    cards[name].Add(sum);
                }
                line = Console.ReadLine();

            }
            foreach (var pair in cards)
            {
                var name = pair.Key;
                var cardSum = pair.Value.Sum();

                Console.WriteLine($"{name}: {cardSum}");
            }
        }

        private static Dictionary<string, int> GetCardPowers()
        {
            var powers = new Dictionary<string, int>();

            for (int i = 2; i <= 10; i++)
            {
                powers[i.ToString()] = i;
            }

            powers["J"] = 11;
            powers["Q"] = 12;
            powers["K"] = 13;
            powers["A"] = 14;

            return powers;
        }

        private static Dictionary<string, int> GetCardTypes()
        {
            var cardTypes = new Dictionary<string, int>();

            cardTypes["S"] = 4;
            cardTypes["H"] = 3;
            cardTypes["D"] = 2;
            cardTypes["C"] = 1;

            return cardTypes;

        }
    }
}
