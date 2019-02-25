using System;

public class Competitor : IComparable<Competitor>
{
    public Competitor(int id, string name)
    {
        this.Id = id;
        this.Name = name;
        this.TotalScore = 0;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public long TotalScore { get; set; }

    public int CompareTo(Competitor other)
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
            Competitor competitor = (Competitor)obj;
            return (this.Id == competitor.Id);
        }
    }

    public override int GetHashCode()
    {
        return (this.Id << 2) * this.Name.Length;
    }
}
