using NUnit.Framework;
using System.Linq;

public class Test18
{
    [TestCase]
    public void FindCompetitorsInRange_With_Max_Value_Inclusive()
    {
        //Arrange

        var olympics = new Olympics();

        //Act

        olympics.AddCompetition(1, "SoftUniada", 500);
        olympics.AddCompetition(2, "Java", 600);

        olympics.AddCompetitor(5, "Ani");
        olympics.Compete(5, 1);
        olympics.Compete(5, 2);

        olympics.AddCompetitor(1, "Ivan");
        olympics.Compete(1, 1);

        olympics.AddCompetitor(2, "Stamat");
        olympics.Compete(2, 1);
        olympics.Compete(2, 2);

        int expectedCount = 2;
        int actualCount = olympics.FindCompetitorsInRange(500, 1100).Count();


        //Assert

        Assert.AreEqual(expectedCount, actualCount);

    }
}