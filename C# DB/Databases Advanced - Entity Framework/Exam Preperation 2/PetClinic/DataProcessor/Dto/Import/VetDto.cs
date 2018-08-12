using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor.Dto.Import
{
    [XmlType("Vet")]
    public class VetDto
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [XmlElement("Profession")]
        public string Profession { get; set; }

        [Required]
        [Range(22, 65)]
        [XmlElement("Age")]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"(\+359[0-9]{9})|(0[0-9]{9})")]
        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
