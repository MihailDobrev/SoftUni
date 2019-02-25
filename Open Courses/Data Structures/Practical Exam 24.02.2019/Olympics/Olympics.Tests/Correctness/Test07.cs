using NUnit.Framework;
using System;

public class Test07
{
    [TestCase]
    public void Compete_With_Invalid_Competition_Id_Should_Throw_Exception()
    {
        //Arrange

        var olympics = new Olympics();

        //Act

        olympics.AddCompetition(1, "SoftUniada", 500);
        olympics.AddCompetitor(5, "Ani");
        olympics.Compete(5, 1);

        //Assert

        Assert.Throws<ArgumentException>(() => olympics.Compete(5, 7));

    }
}
