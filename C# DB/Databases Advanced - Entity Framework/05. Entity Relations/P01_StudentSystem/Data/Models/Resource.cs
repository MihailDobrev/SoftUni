namespace P01_StudentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {
        [Key]
        [Required]
        public int ResourceId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        public ResourceType ResourceType { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
