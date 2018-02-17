using System;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        int numberofPeople = int.Parse(Console.ReadLine());
        Team team = new Team("First team");
        Team secondTeam = new Team("Reserve team");

        for (int line = 0; line < numberofPeople; line++)
        {
            string[] inputArgs = Console.ReadLine().Split().Where(i => i != string.Empty).ToArray();
            string firstName = inputArgs[0];
            string lastName = inputArgs[1];
            int age = int.Parse(inputArgs[2]);
            double salary = double.Parse(inputArgs[3]);
            Person person = new Person(firstName, lastName, age, salary);
            team.AddPlayer(person);
        }

        Console.WriteLine(team.ShowAllPlayers());
        

    }
}

