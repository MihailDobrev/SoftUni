using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class Test02
{
    [TestCase]
    public void Draw_Should_Throw_Exception_With_Existing_Name()
    {
        //Arrange
        var card = new Card("Gnome the grudge", 10, 20, 5);
        var card2 = new Card("Gnome the grudge", 10, 15, 5);

        var board = new Board();

        //Act
        board.Draw(card);


        //Assert
        Assert.Throws<ArgumentException>(() => board.Draw(card2), "Adding card with same name should throw exception");

    }
}
