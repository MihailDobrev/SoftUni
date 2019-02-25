using NUnit.Framework;
using System;

public class Test10
{
    [TestCase]
    public void Disqualify_Should_Throw_Exception_With_Invalid_Competition_Id()
    {

        //Arrange

        var olympics = new Olympics();

        //Act

        olympics.AddCompetition(1, "CompetitionOne", 50);
        olympics.AddCompetitor(1, "Ani");
        olympics.Compete(1, 1);

        //Assert

        Assert.Throws<ArgumentException>(() => olympics.Disqualify(2, 1));
    }

}
