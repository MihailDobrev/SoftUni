namespace PetClinic.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Procedure")]
    public class ProcedureDto
    {
        [Required]
        [XmlElement("Vet")]
        public string Vet { get; set; }

        [Required]
        [XmlElement("Animal")]
        public string Animal { get; set; }

        [XmlElement("DateTime")]
        public string DateTime { get; set; }

        [XmlArray("AnimalAids")]
        public AnimalAidDto[] AnimalAids { get; set; }
    }
}
