using NUnit.Framework;
using System.Linq;


public class Test15
{
    [TestCase]
    public void GetByName_Count_Should_Be_Correct()
    {
        //Arrange

        var olympics = new Olympics();

        //Act

        olympics.AddCompetitor(5, "Ani");
        olympics.AddCompetitor(2, "Stamat");
        olympics.AddCompetitor(3, "Stamat");
        var expectedCount = 2;
        var actualCount = olympics.GetByName("Stamat").Count();

        //Assert

        Assert.AreEqual(expectedCount, actualCount);

    }
}
