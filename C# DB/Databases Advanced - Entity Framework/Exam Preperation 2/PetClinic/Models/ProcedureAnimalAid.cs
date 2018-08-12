namespace PetClinic.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProcedureAnimalAid
    {
        [Required]
        public int ProcedureId  { get; set; }

        public Procedure Procedure { get; set; }

        [Required]
        public int AnimalAidId { get; set; }

        public AnimalAid AnimalAid { get; set; }
    }
}