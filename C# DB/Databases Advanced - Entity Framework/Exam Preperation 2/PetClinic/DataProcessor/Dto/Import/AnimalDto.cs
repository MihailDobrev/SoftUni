namespace DataProcessor.Dto.Export
{
    using System.ComponentModel.DataAnnotations;

    public class AnimalDto
    {
     
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Type { get; set; }

        [Range(1, int.MaxValue)]
        public int Age { get; set; }

        public PassportDto Passport { get; set; }
    }
}
