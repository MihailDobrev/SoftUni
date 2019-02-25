using System.Collections.Generic;
public interface IOlympics
{
    void AddCompetitor(int id, string name);

    void AddCompetition(int id, string name, int participantsLimit);

    void Compete(int competitorId, int competitionId);

    void Disqualify(int competitionId, int competitorId);

    IEnumerable<Competitor> FindCompetitorsInRange(long min, long max);

    IEnumerable<Competitor> GetByName(string name);

    IEnumerable<Competitor> SearchWithNameLength(int min, int max);

    bool Contains(int competitionId, Competitor comp);

    int CompetitionsCount();

    int CompetitorsCount();

    Competition GetCompetition(int id);
}