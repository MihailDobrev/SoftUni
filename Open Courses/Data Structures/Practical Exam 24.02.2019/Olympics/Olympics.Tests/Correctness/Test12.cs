using NUnit.Framework;


public class Test12
{
    [TestCase]
    public void Disqualify_Should_Not_Decrease_All_Competitors_Count()
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
        int expectedCompetitorsCount = 3;
        int actualCompetitorsCount = olympics.CompetitorsCount();

        //Assert

        Assert.AreEqual(expectedCompetitorsCount, actualCompetitorsCount);

    }
}
