namespace P02.ExtendedDatabase
{
    public class Person
    {
        public Person(long id, string userName)
        {
            Id = id;
            UserName = userName;
        }

        public long Id { get; private set; }
        public string UserName { get; set; }
    }
}
