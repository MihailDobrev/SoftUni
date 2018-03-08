namespace _08.MilitaryElite
{
    using System;
    public class Spy : ISoldier
    {
        public Spy(int id, string firstName, string lastName, long codeNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CodeNumber = codeNumber;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long CodeNumber { get; set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id} " + Environment.NewLine + $"Code Number: {CodeNumber}";
        }
    }
}
