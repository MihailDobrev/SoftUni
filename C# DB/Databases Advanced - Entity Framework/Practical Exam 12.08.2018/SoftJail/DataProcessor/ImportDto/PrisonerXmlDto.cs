namespace SoftJail.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    [XmlType("Prisoner")]
    public class PrisonerXmlDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}