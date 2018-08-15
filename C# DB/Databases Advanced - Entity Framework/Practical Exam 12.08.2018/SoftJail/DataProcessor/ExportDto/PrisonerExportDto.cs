namespace SoftJail.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Prisoner")]
    public class PrisonerExportDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string IncarcerationDate { get; set; }

        [XmlArray("EncryptedMessages")]
        public MessageDto[] EncryptedMessages { get; set; }

    }
}
