namespace _11.Students_Joined_to_Specialties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            List<StudentSpecialty> studentSpecialties = new List<StudentSpecialty>();

            while (!input.Equals("Students:"))
            {
                var specialtyInfo = input.Split();

                StudentSpecialty studentSpecialty = new StudentSpecialty()
                {
                    SpecialtyName = specialtyInfo[0]+" "+specialtyInfo[1],
                    FacultyNumber = int.Parse(specialtyInfo[2])
                };

                studentSpecialties.Add(studentSpecialty);
                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            List<Student> students = new List<Student>();
            while (!input.Equals("END"))
            {
                var studentInfo = input.Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);

                Student student = new Student()
                {
                    FacultyNumber = int.Parse(studentInfo[0]),
                    StudentName = studentInfo[1] +" "+studentInfo[2]
                };

                students.Add(student);
                input = Console.ReadLine();
            }

            var matchedStudents = studentSpecialties
                .Join(students,
                fac => fac.FacultyNumber,
                st => st.FacultyNumber,
                (fac, st) => new
                {
                    StudentName = st.StudentName,
                    SpecialtyName = fac.SpecialtyName,
                    FacultyNumber=fac.FacultyNumber
                })
                .OrderBy(x=>x.StudentName);

            foreach (var match in matchedStudents)
            {
                Console.WriteLine($"{match.StudentName} {match.FacultyNumber} {match.SpecialtyName}");
            }
        }
    }
  
}
