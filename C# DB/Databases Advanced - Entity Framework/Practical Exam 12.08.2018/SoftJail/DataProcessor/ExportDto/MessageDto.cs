namespace SoftJail.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Message")]
    public class MessageDto
    {
        public string Description { get; set; }
    }
}