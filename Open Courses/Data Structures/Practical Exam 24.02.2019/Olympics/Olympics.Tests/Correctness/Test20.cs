using NUnit.Framework;
using System.Linq;

public class Test20
{
    [TestCase]
    public void SearchWithNameLength_With_Invalid_Range_Should_Return_Empty_Collection()
    {

        //Arrange

        var olympics = new Olympics();

        //Act

        olympics.AddCompetitor(1, "Ani");
        olympics.AddCompetitor(2, "Georgi");
        olympics.AddCompetitor(3, "Ivan");
        olympics.AddCompetitor(4, "Stamat");
        olympics.AddCompetitor(5, "Georgi");
        olympics.AddCompetitor(6, "Ivo");
        olympics.AddCompetitor(7, "Galin");
        olympics.AddCompetitor(8, "Mariika");
        olympics.AddCompetitor(9, "Asd");
        olympics.AddCompetitor(10, "Ani");

        var competitors = olympics.SearchWithNameLength(0, 2);

        //Assert

        Assert.AreEqual(Enumerable.Empty<Competitor>(), competitors);
    }
}
