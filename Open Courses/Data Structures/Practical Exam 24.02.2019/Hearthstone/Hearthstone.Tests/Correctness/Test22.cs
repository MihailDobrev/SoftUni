using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Test22
{
    [TestCase]
    public void ListCardsByPrefix_Should_Return_Correct_Order_Of_Cards()
    {
        //Arrange
        var card = new Card("Best card", 10, 20, 5);
        var card2 = new Card("Cool chocolate", 10, 15, 5);
        var card3 = new Card("Cosmic magic", 6, 8, 3);
        var card4 = new Card("Combat card", 10, 8, 2);

        var board = new Board();

        //Act
        board.Draw(card);
        board.Draw(card2);
        board.Draw(card3);
        board.Draw(card4);

        var expected = new List<Card>()
            {
                new Card("Cosmic magic", 6, 8, 3),
                new Card("Combat card", 10, 8, 2),
                new Card("Cool chocolate", 10, 15, 5)
            };

        var actual = board.ListCardsByPrefix("Co").ToList();

        //Assert
        Assert.IsTrue(actual.SequenceEqual(expected));

    }
}
