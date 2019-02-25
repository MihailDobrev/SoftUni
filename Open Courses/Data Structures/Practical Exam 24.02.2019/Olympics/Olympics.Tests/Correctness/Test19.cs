using NUnit.Framework;
using System.Linq;

public class Test19
{
    [TestCase]
    public void FindCompetitorsInRange_Correct_Order()
    {
        //Arrange

        var olympics = new Olympics();

        //Act

        olympics.AddCompetition(1, "SoftUniada", 500);
        olympics.AddCompetition(2, "Java", 600);

        olympics.AddCompetitor(5, "Ani");
        olympics.Compete(5, 1);
        olympics.Compete(5, 2);

        olympics.AddCompetitor(1, "Ivan");
        olympics.Compete(1, 1);

        olympics.AddCompetitor(2, "Stamat");
        olympics.Compete(2, 1);
        olympics.Compete(2, 2);

        int[] ids = { 1, 2, 5 };
        bool isCorrectOrder = true;

        var competitors = olympics.FindCompetitorsInRange(400, 1100).ToList();

        for (int i = 0; i < ids.Length; i++)
        {
            if (competitors[i].Id != ids[i])
            {
                isCorrectOrder = false;
                break;
            }
        }

        //Assert

        Assert.IsTrue(isCorrectOrder);

    }
}
