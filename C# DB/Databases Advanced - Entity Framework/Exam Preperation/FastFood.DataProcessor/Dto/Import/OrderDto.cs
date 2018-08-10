namespace FastFood.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Order")]
    public class OrderDto
    {
        [Required]
        [XmlElement("Customer")]
        public string Customer { get; set; }

        [XmlElement("Employee")]
        public string Employee { get; set; }

        [Required]
        [XmlElement("DateTime")]
        public string DateTime { get; set; }

        [XmlElement("Type")]
        public string Type { get; set; }

        [XmlArray("Items")]
        public OrderItemDto[] OrderItems { get; set; }
    }
}
