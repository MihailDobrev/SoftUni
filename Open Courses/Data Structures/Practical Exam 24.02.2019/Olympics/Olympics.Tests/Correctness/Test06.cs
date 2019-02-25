using NUnit.Framework;

public class Test06
{
    [TestCase]
    public void GetCompetition_Should_Return_Correct_Competition()
    {
        //Arrange

        var olympics = new Olympics();
        int id = 1;
        string name = "SoftUniada";
        int score = 500;

        //Act

        olympics.AddCompetition(id, name, score);
        Competition competition = olympics.GetCompetition(id);
        bool isCorrectCompetition = competition.Id == id && competition.Name == name && competition.Score == score;

        //Assert

        Assert.IsTrue(isCorrectCompetition);


    }
}