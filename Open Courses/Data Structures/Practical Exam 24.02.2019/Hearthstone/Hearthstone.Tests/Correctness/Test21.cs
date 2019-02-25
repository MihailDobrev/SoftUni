using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Test21
{
    [TestCase]
    public void ListCardsByPrefix_Should_Return_Correct_Count_Of_Cards()
    {
        //Arrange
        var card = new Card("Best card", 10, 20, 5);
        var card2 = new Card("Cool card", 10, 15, 5);
        var card3 = new Card("Cosmic magic Card", 6, 8, 3);
        var card4 = new Card("Combat card", 10, 8, 2);

        var board = new Board();

        //Act
        board.Draw(card);
        board.Draw(card2);
        board.Draw(card3);
        board.Draw(card4);

        var actual = board.ListCardsByPrefix("Co").Count();

        //Assert
        Assert.AreEqual(3, actual);

    }
}
