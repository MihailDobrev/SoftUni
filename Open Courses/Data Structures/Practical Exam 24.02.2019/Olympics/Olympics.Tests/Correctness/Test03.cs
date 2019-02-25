using NUnit.Framework;


public class Test03
{

    [TestCase]
    public void AddCompetition_Count_Should_Increase()
    {
        //Arrange
        var olympics = new Olympics();

        //Act
        olympics.AddCompetition(1, "SoftUniada", 500);
        olympics.AddCompetition(2, "CodeWizard", 600);
        olympics.AddCompetition(3, "Programming Basics", 100);
        olympics.AddCompetition(4, "CSharpForDummies", 20);

        int expectedCount = 4;
        int actualCount = olympics.CompetitionsCount();

        //Assert
        Assert.AreEqual(expectedCount, actualCount);
    }
}
