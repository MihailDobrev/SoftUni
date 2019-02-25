using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
public class Test06
{
    [TestCase]
    public void Count_Should_Return_Zero_When_Deck_Has_No_Elements()
    {
        //Arrange

        var board = new Board();

        //Act;

        int count = board.Count();
        //Assert

        Assert.AreEqual(0, count);

    }
}
