using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

public class PTest04 
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
    public void Compete_10_000_competitors_with_1_000_competitions()
    {
        int initialCompetitorsCount = 5000;
        int initialCompetitionsCount = 1000;

        List<Competition> competitions = this.inputGenerator.GenerateCompetitions(initialCompetitionsCount);
        List<Competitor> competitors = this.inputGenerator.GenerateCompetitors(initialCompetitorsCount);

        competitions.ForEach(c=> this.olympics.AddCompetition(c.Id, c.Name, c.Score));
        competitors.ForEach(c=> this.olympics.AddCompetitor(c.Id, c.Name));

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        foreach (Competition competition in competitions)
        {
            foreach (Competitor competitor in competitors)
            {
                this.olympics.Compete(competitor.Id, competition.Id);
            }
        }

        stopwatch.Stop();


        long executionTimeInMillis = stopwatch.ElapsedMilliseconds;

        Assert.IsTrue(executionTimeInMillis <= 1000);
        int count = 0;
        foreach (Competition c in competitions)
        {
            count += this.olympics.GetCompetition(c.Id).Competitors.Count;
        }
        Assert.AreEqual( count, initialCompetitorsCount * initialCompetitionsCount);
    }
}
