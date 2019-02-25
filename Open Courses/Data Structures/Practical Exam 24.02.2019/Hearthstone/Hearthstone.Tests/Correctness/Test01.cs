using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class Test01
{
    [TestCase]
    public void Draw_Should_Increase_Count()
    {
        //Arrange
        var card = new Card("Gnome the grudge", 10, 20, 5);
        var card2 = new Card("Magic Card", 10, 15, 5);

        var board = new Board();

        //Act
        board.Draw(card);
        board.Draw(card2);

        //Assert
        Assert.AreEqual(2, board.Count());

    }
}
