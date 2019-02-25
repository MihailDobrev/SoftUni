using System;
using System.Collections.Generic;
using System.Linq;

public class Olympics : IOlympics
{
    private Dictionary<int, Competition> competitions;
    private Dictionary<int, Competitor> competitors;

    public Olympics()
    {
        this.competitions = new Dictionary<int, Competition>();
        this.competitors = new Dictionary<int, Competitor>();
    }

    public void AddCompetition(int id, string name, int participantsLimit)
    {
        if (this.competitions.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        this.competitions.Add(id, new Competition(name, id, participantsLimit));
    }

    public void AddCompetitor(int id, string name)
    {
        if (this.competitors.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        this.competitors.Add(id, new Competitor(id, name));
    }

    public void Compete(int competitorId, int competitionId)
    {
        if (!this.competitors.ContainsKey(competitorId) || !this.competitions.ContainsKey(competitionId))
        {
            throw new ArgumentException();
        }

        this.competitors[competitorId].TotalScore = competitions[competitionId].Score;
       
        this.competitions[competitionId].Competitors.Add(this.competitors[competitorId]);
    }

    public int CompetitionsCount()
    {
        return this.competitions.Count;
    }

    public int CompetitorsCount()
    {
        return this.competitors.Count;
    }

    public bool Contains(int competitionId, Competitor comp)
    {
        if (!this.competitions.ContainsKey(competitionId) || !this.competitors.ContainsKey(comp.Id))
        {
            throw new ArgumentException();
        }

        var competitor = this.competitions[competitionId].Competitors.FirstOrDefault(x => x.Id==comp.Id);

        return competitor != null;
    }

    public void Disqualify(int competitionId, int competitorId)
    {
        if (!this.competitors.ContainsKey(competitorId) || !this.competitions.ContainsKey(competitionId))
        {
            throw new ArgumentException();
        }

        this.competitors[competitorId].TotalScore -= this.competitions[competitionId].Score;

        this.competitions[competitionId].Competitors.Remove(this.competitors[competitorId]);
    }

    public IEnumerable<Competitor> FindCompetitorsInRange(long min, long max)
    {
        return this.competitors.Values.Where(x => x.TotalScore > min && x.TotalScore <= max)
            .OrderBy(x=>x.Id);
    }

    public IEnumerable<Competitor> GetByName(string name)
    {
        var competitors = this.competitors.Values.Where(x => x.Name == name)
            .OrderBy(x => x.Id);

        if (competitors.Count()==0)
        {
            throw new ArgumentException();
        }

        return competitors;
    }

    public Competition GetCompetition(int id)
    {
        if (!this.competitions.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        return this.competitions[id];
    }

    public IEnumerable<Competitor> SearchWithNameLength(int min, int max)
    {
        var withNameLenght = this.competitors.Values.Where(x => x.Name.Length >= min && x.Name.Length <= max)
            .OrderBy(x=>x.Id);

        if (withNameLenght.Count()==0)
        {
            return Enumerable.Empty<Competitor>();
        }

        return withNameLenght;
    }
}