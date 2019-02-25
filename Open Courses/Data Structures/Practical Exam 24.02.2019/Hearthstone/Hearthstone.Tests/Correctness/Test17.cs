using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Test17
{

    [TestCase]
    public void GetBestOfRange_Should_Return_Empty_Collection_With_Invalid_Range()
    {
        //Arrange
        var card = new Card("Gnome the grudge", 10, 20, 5);
        var card2 = new Card("Magic Card", 10, 15, 5);
        var card3 = new Card("No magic Card", 6, 8, 3);
        var card4 = new Card("Simple card", 10, 8, 3);

        var board = new Board();

        //Act
        board.Draw(card);
        board.Draw(card2);
        board.Draw(card3);
        board.Draw(card4);



        //Assert
        Assert.AreEqual(Enumerable.Empty<Card>(), board.GetBestInRange(1, 5));

    }
}
