public class Person
{
    public string name;
    public int age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}
