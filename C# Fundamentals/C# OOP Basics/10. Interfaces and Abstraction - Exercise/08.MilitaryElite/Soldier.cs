namespace _08.MilitaryElite
{
    public class Soldier
    {
        public Soldier(int id, string firstName, string lastName, decimal salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}";
        }
    }
}
