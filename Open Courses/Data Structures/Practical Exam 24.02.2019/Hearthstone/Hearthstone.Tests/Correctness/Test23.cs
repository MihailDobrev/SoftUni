using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Test23
{
    [TestCase]
    public void SearchByLevel_Should_Return_Correct_Count_Of_Cards()
    {
        //Arrange
        var card = new Card("Best card", 10, 20, 5);
        var card2 = new Card("Cool chocolate", 10, 15, 5);
        var card3 = new Card("Cosmic magic", 6, 8, 2);
        var card4 = new Card("Combat card", 10, 8, 2);
        var card5 = new Card("NotCombat card", 10, 8, 2);
        var card6 = new Card("Special card", 10, 8, 2);

        var board = new Board();

        //Act
        board.Draw(card);
        board.Draw(card2);
        board.Draw(card3);
        board.Draw(card4);
        board.Draw(card5);
        board.Draw(card6);

        var expected = 4;
        var actual = board.SearchByLevel(2).Count();

        //Assert
        Assert.AreEqual(expected, actual);

    }
}
