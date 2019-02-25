using NUnit.Framework;
using System;
public class Test23
{
    [TestCase]
    public void Contains_Should_Throw_Exception_With_Invalid_Id()
    {
        //Arrange

        var olympics = new Olympics();
        var competitor = new Competitor(5, "Ani");

        //Act

        olympics.AddCompetition(1, "SoftUniada", 500);

        olympics.AddCompetitor(5, "Ani");

        //Assert

        Assert.Throws<ArgumentException>(() => olympics.Contains(2, competitor));
    }

}
