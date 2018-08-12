namespace PetClinic.DataProcessor.Dto.Export
{
    using System.Xml.Serialization;
    [XmlType("AnimalAid")]

    public class ExportAnimalAidDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}
