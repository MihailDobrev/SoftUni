using NUnit.Framework;

public class Test11
{
    [TestCase]
    public void Disqualify_Should_Decrease_Competitors_Count_In_Competition()
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
        olympics.Disqualify(1, 5);
        int expectedCompetitorsCount = 2;
        int actualCompetitorsCount = olympics.GetCompetition(1).Competitors.Count;

        //Assert

        Assert.AreEqual(expectedCompetitorsCount, actualCompetitorsCount);

    }
}
