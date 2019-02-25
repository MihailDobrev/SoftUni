using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
public class Test25
{
    [TestCase]
    public void Heal_Should_Work_Correct()
    {
        //Arrange
        var card = new Card("Best card", 10, 20, 5);
        var card2 = new Card("Cool chocolate", 10, 15, 5);
        var card3 = new Card("Cosmic magic", 6, 8, 2);
        var card4 = new Card("Combat card", 10, 4, 2);
        var card5 = new Card("NotCombat card", 10, 9, 2);
        var card6 = new Card("Special card", 10, 3, 2);

        var board = new Board();

        //Act
        board.Draw(card);
        board.Draw(card2);
        board.Draw(card3);
        board.Draw(card4);
        board.Draw(card5);
        board.Draw(card6);

        board.Play("NotCombat card", "Special card");
        board.Play("NotCombat card", "Special card");
        board.Play("Cosmic magic", "NotCombat card");
        board.Play("Cosmic magic", "NotCombat card");
        board.Play("Cosmic magic", "NotCombat card");
        board.Play("Cosmic magic", "NotCombat card");

        board.Heal(13);

        //Assert
        Assert.AreEqual(9, card5.Health);

    }
}
