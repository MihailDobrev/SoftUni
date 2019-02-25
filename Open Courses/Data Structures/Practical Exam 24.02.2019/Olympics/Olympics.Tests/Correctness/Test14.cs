using NUnit.Framework;
using System;

public class Test14
{
    [TestCase]
    public void GetByName_Should_Throw_Exception_With_Invalid_Name()
    {
        //Arrange

        var olympics = new Olympics();

        //Act

        olympics.AddCompetitor(5, "Ani");
        olympics.AddCompetitor(2, "Stamat");

        //Assert
        Assert.Throws<ArgumentException>(() => olympics.GetByName("Misho"));

    }
}
