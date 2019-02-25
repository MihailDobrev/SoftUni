using System;
using System.Collections.Generic;

public class Competition : IComparable<Competition>
{
    public Competition(string name, int id, int score)
    {
        this.Name = name;
        this.Id = id;
        this.Score = score;
        this.Competitors = new List<Competitor>();
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public int Score { get; set; }

    public ICollection<Competitor> Competitors { get; set; }

    public int CompareTo(Competition other)
    {
        return this.Id.CompareTo(other.Id);
    }

    public override bool Equals(Object obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            Competition competition = (Competition)obj;
            return (this.Id == competition.Id);
        }
    }

    public override int GetHashCode()
    {
        return (this.Id << 2) * this.Name.Length;
    }
}
