namespace _03._Student_System
{
     public class Student
    {
        public Student(string name, int age, double mark)
        {
            Name = name;
            Age = age;
            Mark = mark;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public double Mark { get; set; }
    }
}
