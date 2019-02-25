using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class PTest11 
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
    public void SearchWithNameLength_500_000_competitors()
    {

        int initialCount = 500000;

        List<Competitor> competitors = this.inputGenerator.GenerateCompetitors(initialCount);
        int countNames = 0;

        foreach (Competitor competitor in competitors)
        {
            this.olympics.AddCompetitor(competitor.Id, competitor.Name);
            if (competitor.Name.Length == 3)
            {
                countNames++;
            }
        }
        Stopwatch stopwacth = new Stopwatch();
        stopwacth.Start();

        IEnumerable<Competitor> competitorsByNameLength = this.olympics.SearchWithNameLength(3, 3);
        stopwacth.Stop();
        long executionTimeInMillis = stopwacth.ElapsedMilliseconds;

        int countCompetitorsInRange = competitorsByNameLength.Count();

        Assert.IsTrue(executionTimeInMillis <= 150);
        Assert.AreEqual(countNames, countCompetitorsInRange);
    }
}
