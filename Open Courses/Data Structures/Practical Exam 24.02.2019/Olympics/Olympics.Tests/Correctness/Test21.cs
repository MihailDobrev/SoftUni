using NUnit.Framework;
using System.Linq;

public class Test21
{
    [TestCase]
    public void SearchWithNameLength_Max_Value_Inclusive()
    {
        //Arrange

        var olympics = new Olympics();

        //Act

        olympics.AddCompetitor(1, "Ani");
        olympics.AddCompetitor(10, "Ani");
        olympics.AddCompetitor(6, "Ivo");
        olympics.AddCompetitor(9, "Asd");
        olympics.AddCompetitor(2, "Georgi");
        olympics.AddCompetitor(3, "Ivan");
        olympics.AddCompetitor(4, "Stamat");
        olympics.AddCompetitor(5, "Georgi");
        olympics.AddCompetitor(7, "Galin");
        olympics.AddCompetitor(8, "Mariika");

        int expectedCount = 10;
        int actualCount = olympics.SearchWithNameLength(3, 7).Count();

        //Assert

        Assert.AreEqual(expectedCount, actualCount);
    }

}
