using NUnit.Framework;

public class Test09
{
    [TestCase]
    public void Compete_With_Valid_Competitors_In_Competition_Score_Changed()
    {
        //Arrange

        var olympics = new Olympics();

        //Act

        olympics.AddCompetition(1, "SoftUniada", 500);

        olympics.AddCompetitor(5, "Ani");
        olympics.Compete(5, 1);

        olympics.AddCompetitor(1, "Ivan");
        olympics.Compete(1, 1);

        olympics.AddCompetitor(2, "Stamat");
        olympics.Compete(2, 1);

        int expectedCompetitorsScore = 1500;
        long actualCompetitorsScore = 0;

        foreach (Competitor competitor in olympics.GetCompetition(1).Competitors)
        {
            actualCompetitorsScore += competitor.TotalScore;
        }

        //Assert

        Assert.AreEqual(expectedCompetitorsScore, actualCompetitorsScore);

    }
}
