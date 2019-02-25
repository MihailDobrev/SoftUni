using NUnit.Framework;
using System.Linq;

public class Test16
{
    [TestCase]
    public void GetByName_Order_Should_Be_Correct()
    {

        //Arrange

        var olympics = new Olympics();

        //Act

        olympics.AddCompetitor(5, "Ani");
        olympics.AddCompetitor(2, "Stamat");
        olympics.AddCompetitor(3, "Stamat");
        olympics.AddCompetitor(8, "Stamat");
        olympics.AddCompetitor(22, "Stamat");
        olympics.AddCompetitor(15, "Stamat");
        int[] ids = { 2, 3, 8, 15, 22 };
        bool isCorrectOrder = true;

        var competitors = olympics.GetByName("Stamat").ToList();

        for (int i = 0; i < ids.Length; i++)
        {
            if (ids[i] != competitors[i].Id)
            {
                isCorrectOrder = false;
                break;
            }
        }

        //Assert

        Assert.IsTrue(isCorrectOrder);

    }
}
