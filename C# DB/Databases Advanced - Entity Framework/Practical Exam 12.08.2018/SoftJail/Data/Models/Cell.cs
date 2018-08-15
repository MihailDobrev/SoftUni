namespace SoftJail.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Cell
    {
        public Cell()
        {
            Prisoners = new HashSet<Prisoner>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1,1000)]
        public int CellNumber  { get; set; }

        [Required]
        public bool HasWindow  { get; set; }

        [Required]
        public int DepartmentId  { get; set; }

        public Department Department  { get; set; }

        public ICollection<Prisoner> Prisoners  { get; set; }
    }
}