using NUnit.Framework;
using System.Linq;

public class Test13
{
    [TestCase]
    public void Disqualify_Should_Reduce_Score()
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

        int expectedScore = 0;
        long actualCompetitorsScore = olympics.GetByName("Ani").Sum(a => a.TotalScore);

        //Assert

        Assert.AreEqual(expectedScore, actualCompetitorsScore);

    }
}
