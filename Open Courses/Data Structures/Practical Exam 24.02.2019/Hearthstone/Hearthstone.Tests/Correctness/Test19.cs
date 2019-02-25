using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Test19
{
    [TestCase]
    public void GetBestOfRange_Should_Be_In_Same_Order()
    {
        //Arrange
        var card = new Card("Gnome the grudge", 10, 20, 5);
        var card2 = new Card("Magic Card", 10, 15, 5);
        var card3 = new Card("No magic Card", 6, 8, 3);
        var card4 = new Card("Simple card", 10, 8, 2);

        var board = new Board();

        //Act
        board.Draw(card);
        board.Draw(card2);
        board.Draw(card3);
        board.Draw(card4);

        var expected = new List<Card>()
            {
                new Card("Magic Card", 10, 15, 5),
                new Card("No magic Card", 6, 8, 3),
                new Card("Simple card", 10, 8, 2)
            };
        var actual = board.GetBestInRange(8, 15).ToList();

        //Assert
        Assert.IsTrue(actual.SequenceEqual(expected));

    }
}
