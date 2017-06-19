

namespace _4.Average_Grades
{
    using System.Collections.Generic;
    using System.Linq;
    public class Student
    {
        public string Name { get; set; }

        public List<double>Grades { get; set; }

        public double AverageGrade => Grades.Average();
    }
}
