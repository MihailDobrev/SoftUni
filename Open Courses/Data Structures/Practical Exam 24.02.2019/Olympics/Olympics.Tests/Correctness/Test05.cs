using NUnit.Framework;
using System;

public class Test05
{
    [TestCase]
    public void GetCompetition_With_Invalid_Id_Should_Throw_Exception()
    {
        //Arrange

        var olympics = new Olympics();
        int id = 1;
        string name = "SoftUniada";
        int score = 500;

        //Act

        olympics.AddCompetition(id, name, score);

        //Assert

        Assert.Throws<ArgumentException>(() => olympics.GetCompetition(int.MinValue));

    }
}
