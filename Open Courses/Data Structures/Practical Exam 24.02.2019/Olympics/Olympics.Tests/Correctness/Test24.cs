using NUnit.Framework;

public class Test24
{
    [TestCase]
    public void Contains_Should_Return_True_With_Valid_Data()
    {
        //Arrange

        var olympics = new Olympics();
        var competitor = new Competitor(5, "Ani");

        //Act

        olympics.AddCompetition(1, "SoftUniada", 500);

        olympics.AddCompetitor(5, "Ani");
        olympics.Compete(5, 1);

        var actual = olympics.Contains(1, competitor);

        //Assert

        Assert.IsTrue(actual);
    }
}
