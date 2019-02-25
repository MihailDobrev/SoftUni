using NUnit.Framework;
public class Test01
{
    [TestCase]
    public void AddCompetitor_Count_Should_Increase()
    {
        //Arrange
        var olympics = new Olympics();
        olympics.AddCompetitor(1, "Ani");
        olympics.AddCompetitor(2, "Ivan");
        olympics.AddCompetitor(3, "Galin");
        olympics.AddCompetitor(4, "Kali");

        //Act
        int expectedCount = 4;
        int actualCount = olympics.CompetitorsCount();

        //Assert
        Assert.AreEqual(expectedCount, actualCount);

    }
}
