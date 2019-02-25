using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Board : IBoard
{
    private Dictionary<string, Card> deck;

    public Board()
    {
        deck = new Dictionary<string, Card>();
    }

    public bool Contains(string name)
    {
        return this.deck.ContainsKey(name);
    }

    public int Count()
    {
        return this.deck.Count;
    }

    public void Draw(Card card)
    {
        if (this.Contains(card.Name))
        {
            throw new ArgumentException();
        }

        this.deck.Add(card.Name, card);
    }

    public IEnumerable<Card> GetBestInRange(int start, int end)
    {
        var cardsWithZeroOrLowerHealth = this.deck.Values
            .Where(x => x.Score >= start && x.Score <= end)
            .OrderByDescending(x => x.Level);

        if (cardsWithZeroOrLowerHealth.Count() == 0)
        {
            return Enumerable.Empty<Card>();
        }

        return cardsWithZeroOrLowerHealth;
    }

    public void Heal(int health)
    {
        var weakestCard = this.deck.Values.OrderBy(x => x.Health).FirstOrDefault();

        if (weakestCard != null)
        {
            weakestCard.Health += health;
        }

    }

    public IEnumerable<Card> ListCardsByPrefix(string prefix)
    {
        var byPrefix = this.deck.Values.Where(x => x.Name.StartsWith(prefix))
            .OrderBy(x=>ReverseString(x.Name),StringComparer.Ordinal)
            .ThenBy(x=>x.Level);

        if (byPrefix.Count() == 0)
        {
            return Enumerable.Empty<Card>();
        }

        return byPrefix;
    }

    public string ReverseString(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }

    public void Play(string attackerCardName, string attackedCardName)
    {
        if (!this.Contains(attackerCardName) || !this.Contains(attackedCardName))
        {
            throw new ArgumentException();
        }

        var attacker = this.deck[attackerCardName];
        var target = this.deck[attackedCardName];

        if (attacker.Level != target.Level)
        {
            throw new ArgumentException();
        }

        if (attacker.Health > 0)
        {
            if (target.Health <= 0)
            {
                return;
            }
            target.Health -= attacker.Damage;

            if (target.Health <= 0)
            {
                attacker.Score += target.Level;
            }
        }

    }

    public void Remove(string name)
    {
        if (!this.Contains(name))
        {
            throw new ArgumentException();
        }

        this.deck.Remove(name);
    }

    public void RemoveDeath()
    {
        var cardsWithZeroOrLowerHealth = this.deck.Values.Where(x => x.Health <= 0).ToArray();

        foreach (var card in cardsWithZeroOrLowerHealth)
        {
            this.deck.Remove(card.Name);
        }
    }

    public IEnumerable<Card> SearchByLevel(int level)
    {
        return this.deck.Values
            .Where(x => x.Level == level)
            .OrderByDescending(x => x.Score);
    }
}