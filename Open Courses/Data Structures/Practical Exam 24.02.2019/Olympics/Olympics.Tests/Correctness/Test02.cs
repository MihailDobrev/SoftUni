using NUnit.Framework;
using System;

public class Test02
{
    [TestCase]
    public void AddCompetitor_With_Existing_Id_Should_Throw_Exception()
    {
        //Arrange
        var olympics = new Olympics();

        //Act
        olympics.AddCompetitor(1, "Ani");
        olympics.AddCompetitor(3, "Galin");
        olympics.AddCompetitor(4, "Kali");

        //Assert
        Assert.Throws<ArgumentException>(() => olympics.AddCompetitor(1, "Ivan"));

    }
}
