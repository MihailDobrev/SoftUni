using NUnit.Framework;
using System;

public class Test04
{

    [TestCase]
    public void AddCompetition_With_Existing_Id_Should_Throw_Exception()
    {
        //Arrange
        IOlympics olympics = new Olympics();

        //Act
        olympics.AddCompetition(1, "SoftUniada", 500);
        olympics.AddCompetition(2, "CodeWizard", 600);
        olympics.AddCompetition(3, "Programming Basics", 100);


        //Assert
        Assert.Throws<ArgumentException>(() => olympics.AddCompetition(1, "CSharpForDummies", 20));
    }
}
