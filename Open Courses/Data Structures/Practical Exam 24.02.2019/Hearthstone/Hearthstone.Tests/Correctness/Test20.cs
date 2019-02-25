using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Test20
{
    [TestCase]
    public void ListCardsByPrefix_Should_Return_Empty_Collection_With_Invalid_Sufficks()
    {
        //Arrange
        var card = new Card("Best card", 10, 20, 5);
        var card2 = new Card("Cool card", 10, 15, 5);
        var card3 = new Card("No magic Card", 6, 8, 3);
        var card4 = new Card("Simple card", 10, 8, 2);

        var board = new Board();

        //Act
        board.Draw(card);
        board.Draw(card2);
        board.Draw(card3);
        board.Draw(card4);

        var actual = board.ListCardsByPrefix("Mo");

        //Assert
        Assert.AreEqual(Enumerable.Empty<Card>(), actual);

    }
}
