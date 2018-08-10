namespace FastFood.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Item")]
    public class OrderItemDto
    {
        [Required]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [XmlElement("Quantity")]
        public int Quantity { get; set; }
    }
}
