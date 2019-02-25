using System;
using System.Collections.Generic;
using System.Text;

public class Card : IComparable<Card>
{

    public Card(string name, int damage, int score, int level)
    {
        this.Name = name;
        this.Damage = damage;
        this.Score = score;
        this.Level = level;
        this.Health = 20;
    }
    public string Name { get; set; }

    public int Damage { get; set; }

    public int Score { get; set; }

    public int Health { get; set; }

    public int Level { get; set; }

    public int CompareTo(Card other)
    {
        return this.Name.CompareTo(other.Name);
    }

    public override bool Equals(Object obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            Card card = (Card)obj;
            return (Name == card.Name);
        }
    }

    public override int GetHashCode()
    {
        return (this.Name.Length << 2) * this.Damage;
    }
}