using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class PTest08
{
    protected Olympics olympics;
    protected InputGenerator inputGenerator;

    protected class InputGenerator
    {

        private string[] COMPETITOR_NAMES = { "Ani", "Ani", "Ivo", "Asd", "Georgi", "Ivan", "Stamat", "Georgi", "Galin", "Mariika", "Ani", "Ani", "Ivo", "Asd", "Georgi", "Ivan", "Stamat", "Georgi", "Galin", "Mariika", "Ani", "Ani", "Ivo", "Asd", "Georgi", "Ivan", "Stamat", "Georgi", "Galin", "Mariika" };
        private string[] COMPETITION_NAMES = { "Java", "VS", "SoftUniada", "CDiez", "Oracle", "JavaScript", "PHP", "Pascal", "C", "Swift", "Java", "VS", "SoftUniada", "CDiez", "Oracle", "JavaScript", "PHP", "Pascal", "C", "Swift", "Java", "VS", "SoftUniada", "CDiez", "Oracle", "JavaScript", "PHP", "Pascal", "C", "Swift", "Java", "VS", "SoftUniada", "CDiez", "Oracle", "JavaScript", "PHP", "Pascal", "C", "SwiftJava", "VS", "SoftUniada", "CDiez", "Oracle", "JavaScript", "PHP", "Pascal", "C", "SwiftJava", "VS", "SoftUniada", "CDiez", "Oracle", "JavaScript", "PHP", "Pascal", "C", "Swift" };
        public List<Competitor> GenerateCompetitors(int count)
        {
            List<Competitor> competitors = new List<Competitor>();
            for (int i = 1; i <= count; i++)
            {
                competitors.Add(new Competitor(i, COMPETITOR_NAMES[i % COMPETITOR_NAMES.Length]));
            }
            return competitors;
        }

        public List<Competition> GenerateCompetitions(int count)
        {
            List<Competition> competitions = new List<Competition>();
            for (int i = 1; i <= count; i++)
            {
                competitions.Add(new Competition(COMPETITION_NAMES[i % COMPETITION_NAMES.Length], i, 5 + i));
            }
            return competitions;
        }
    }

    [SetUp]
    public void Init()
    {
        this.olympics = new Olympics();
        this.inputGenerator = new InputGenerator();
    }
    [TestCase]
    public void FindCompetitorsInRange_10_000_competitors()
    {

        int initialCount = 10000;
        List<Competition> competitions = this.inputGenerator.GenerateCompetitions(initialCount);
        List<Competitor> competitors = this.inputGenerator.GenerateCompetitors(initialCount);

        competitions.ForEach(c=> this.olympics.AddCompetition(c.Id, c.Name, c.Score));
        competitors.ForEach(c=> this.olympics.AddCompetitor(c.Id, c.Name));

        long totalScore = 0;

        for (int i = 0; i < initialCount; i++)
        {
            Competition competition = competitions[i];
            totalScore += competition.Score;
            this.olympics.Compete(competitors[i].Id, competitions[i].Id);
        }


        Stopwatch stopwacth = new Stopwatch();
        stopwacth.Start();
        IEnumerable<Competitor> competitorsInRange = this.olympics.FindCompetitorsInRange(0, totalScore);
        stopwacth.Stop();
       

        int countCompetitorsInRange = competitorsInRange.Count();

        long executionTimeInMillis = stopwacth.ElapsedMilliseconds;

        Assert.IsTrue(executionTimeInMillis <= 12);
        Assert.AreEqual(initialCount, countCompetitorsInRange);

    }
}
