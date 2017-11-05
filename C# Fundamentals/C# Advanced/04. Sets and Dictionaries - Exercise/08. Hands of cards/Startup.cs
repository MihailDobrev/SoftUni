namespace _08.Hands_of_cards
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            string input = string.Empty;
            Dictionary<string, int> cardPowers = new Dictionary<string, int>()
            {
                {"2", 2 },
                {"3", 3 },
                {"4", 4 },
                {"5", 5 },
                {"6", 6 },
                {"7", 7 },
                {"8", 8 },
                {"9", 9 },
                {"10", 10 },
                {"J", 11 },
                {"Q", 12 },
                {"K", 13 },
                {"A", 14 },
            };

            Dictionary<char, int> cardTypes = new Dictionary<char, int>()
            {
                {'S', 4 },
                {'H', 3 },
                {'D', 2 },
                {'C', 1 }           
            };

            Dictionary<string, int> playerResults = new Dictionary<string, int>();
            Dictionary<string, HashSet<string>> playerCards = new Dictionary<string, HashSet<string>>();

            input = Console.ReadLine();

            while (input!="JOKER")
            {
                HashSet<string> cardsDrawn = new HashSet<string>();
                string[] cardDetails = input.Split(new char[] { ':', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string playerName = cardDetails[0];
                int result = 0;

                for (int i = 1; i < cardDetails.Length; i++)
                {
                    cardsDrawn.Add(cardDetails[i]);
                }

                if (!playerCards.ContainsKey(playerName))
                {
                    playerCards[playerName] = new HashSet<string>();
                }

                HashSet<string> drawnUniqueCards = new HashSet<string>();

                foreach (var card in cardsDrawn)
                {
                    if (!playerCards[playerName].Contains(card))
                    {
                        drawnUniqueCards.Add(card);
                    }
                }

                foreach (var cardDrawn in cardsDrawn)
                {
                    playerCards[playerName].Add(cardDrawn);
                }

                foreach (var uniqueCard in drawnUniqueCards)
                {
                    string cardName = uniqueCard;

                    StringBuilder power = new StringBuilder();

                    for (int i = 0; i < cardName.Length-1; i++)
                    {
                        power.Append(cardName[i]);
                    }

                    char type = cardName[cardName.Length-1];

                    result += cardPowers[power.ToString()] * cardTypes[type];

                }

                if (!playerResults.ContainsKey(playerName))
                {
                    playerResults[playerName] = result;  
                }
                else
                {
                    playerResults[playerName] += result;
                }

                input = Console.ReadLine();
            }

            foreach (var playerResult in playerResults)
            {
                Console.WriteLine($"{playerResult.Key}: {playerResult.Value}");
            }
        }
    }
}
