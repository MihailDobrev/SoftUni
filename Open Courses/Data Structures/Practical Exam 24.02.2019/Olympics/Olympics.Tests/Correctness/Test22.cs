using NUnit.Framework;
using System.Linq;
public class Test22
{
    [TestCase]
    public void SearchWithNameLength_Correct_Order()
    {
        //Arrange

        var olympics = new Olympics();

        //Act

        olympics.AddCompetitor(1, "Ani");
        olympics.AddCompetitor(10, "Ani");
        olympics.AddCompetitor(6, "Ivo");
        olympics.AddCompetitor(9, "Asd");
        olympics.AddCompetitor(2, "Georgi");
        olympics.AddCompetitor(3, "Ivan");
        olympics.AddCompetitor(4, "Stamat");
        olympics.AddCompetitor(5, "Georgi");
        olympics.AddCompetitor(7, "Galin");
        olympics.AddCompetitor(8, "Mariika");

        int[] ids = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        bool isCorrectOrder = true;

        var competitors = olympics.SearchWithNameLength(3, 7).ToList();

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
