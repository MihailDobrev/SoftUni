namespace _06.BirthdayCelebrations
{
    public class Pet : IBirthDate
    {
        public Pet(string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;           
        }

        public string BirthDate { get; set; }

        public string Name { get; set; }
    }
}
