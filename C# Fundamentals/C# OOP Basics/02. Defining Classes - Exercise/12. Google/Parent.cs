namespace _12.Google
{
    public class Parent
    {
        private string name;
        private string birthday;

        public Parent(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
        }

        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
