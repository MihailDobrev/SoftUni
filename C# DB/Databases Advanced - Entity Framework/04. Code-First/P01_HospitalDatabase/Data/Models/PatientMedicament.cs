namespace P01_HospitalDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PatientMedicament
    {
        [Required]
        public int MedicamentId { get; set; }

        public Medicament Medicament { get; set; }

        [Required]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
