using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class Test08
{
    [TestCase]
    public void Play_Should_Throw_Exception_With_Invalid_Attacker_Card()
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
        Assert.Throws<ArgumentException>(() => board.Play("InvalidAttacker", "Magic Card"), "Play with invalid attacker card name should throw exception");

    }
}
