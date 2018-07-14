namespace P01_StudentSystem.Data
{
    using Data.Models;
    using System;
    using System.Collections.Generic;

    public class Configuration
    {
        public const string ConnectionString = "Server=.; Database=StudentSystemDb; Integrated Security=True";

        //Exercise 2.	Seed Some Data in the Database
        public static void Seed(StudentSystemContext context)
        {
            var students = new List<Student>()
            {
                new Student() {  Birthday = new DateTime(2000, 7, 5, 9, 2, 4), Name = "Dimitar Georgiev", PhoneNumber = "0888178456",  RegisteredOn = new DateTime(2015, 8, 23, 1, 8, 10)},
                new Student() {  Birthday = new DateTime(1997, 8, 2, 1, 2, 7), Name = "Valentin Borislavov", PhoneNumber = "0888177852",  RegisteredOn = new DateTime(2016, 4, 17, 1, 8, 10) },
                new Student() {  Birthday = new DateTime(1990, 9, 3, 4, 3, 0), Name = "Ivan Stoev", PhoneNumber = "0888458120",  RegisteredOn = new DateTime(2017, 12, 30, 1, 15, 10) },
            };

            var courses = new List<Course>()
            {
                new Course() { Description = "Micorsoft's ORM technology in .NET Core" , EndDate = new DateTime(2018, 8, 12, 15, 0, 0), Name= "Entity Framework Core", StartDate= new DateTime(2018, 5, 24, 0, 0, 0), Price = 330.00M },
                new Course() { Description = "Part 2 of OOP: Genrics, Reflection, Unit testing" , EndDate = new DateTime(2018, 1, 15, 19, 0, 10), Name= "OOP Advanced", StartDate= new DateTime(2017, 07, 20, 0, 0, 0), Price = 380.00M },
                new Course() { Description = "Learn how to use T-SQL" , EndDate = new DateTime(2017, 2, 5, 7, 8, 0), Name= "Database Basics", StartDate= new DateTime(2016, 10, 5, 0, 0, 0), Price = 270.00M }
            };

            var resources = new List<Resource>()
            {
                new Resource() { CourseId = 1, Name = "Entity Framework Core Code-First", ResourceType = ResourceType.Presentation, Url="www.softuni.bg/ef-core"  },
                new Resource() { CourseId = 2, Name = "Reflection", ResourceType = ResourceType.Video, Url="www.softuni.bg/oop-advanced"  },
                new Resource() { CourseId = 3, Name = "MSSQL Functions", ResourceType = ResourceType.Document, Url="www.softuni.bg/mssql"  },
            };

            var homeworkSumbissions = new List<Homework>()
            {
                new Homework() {  Content="EF core exercises", ContentType = ContentType.Application, SubmissionTime = new DateTime(2018, 3, 1, 7, 0, 0), CourseId = 1, StudentId = 3 },
                new Homework() {  Content="Reflection Description", ContentType = ContentType.Pdf, SubmissionTime = new DateTime(2018, 4, 6, 2, 5, 0), CourseId = 2, StudentId = 1 },
                new Homework() {  Content="Judge submission", ContentType = ContentType.Zip, SubmissionTime = new DateTime(2018, 1, 14, 12, 3, 5), CourseId = 3, StudentId = 2, },
            };

            var studentCourses = new List<StudentCourse>()
            {
                new StudentCourse() {  StudentId = 1,  CourseId = 2 },
                new StudentCourse() {  StudentId = 2,  CourseId = 3 },
                new StudentCourse() {  StudentId = 3,  CourseId = 1 }
            };


            context.Students.AddRange(students);
            context.Courses.AddRange(courses);
            context.Resources.AddRange(resources);
            context.HomeworkSubmissions.AddRange(homeworkSumbissions);
            context.StudentCourses.AddRange(studentCourses);
            context.SaveChanges();

            Console.WriteLine("Data successfully seeded");

        }
    }
}