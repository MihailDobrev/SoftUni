namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        public Student()
        {
            CourseEnrollments = new HashSet<StudentCourse>();
            HomeworkSubmissions = new HashSet<Homework>();
        }

        [Key]
        [Required]
        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<StudentCourse> CourseEnrollments { get; set; }

        public ICollection<Homework> HomeworkSubmissions { get; set; }

    }
}
