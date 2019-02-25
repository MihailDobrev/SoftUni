using NUnit.Framework;

public class Test08
{
    [TestCase]
    public void Compete_With_Valid_Competitors_In_Competition()
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

        int expectedCompetitorsCount = 3;
        int actualCompetitorsCount = olympics.GetCompetition(1).Competitors.Count;

        //Assert

        Assert.AreEqual(expectedCompetitorsCount, actualCompetitorsCount);

    }
}
