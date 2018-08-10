namespace FastFood.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using FastFood.Data;
    using FastFood.DataProcessor.Dto.Export;
    using FastFood.Models.Enums;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
        {

            var employee = context.Employees
                .ToArray()
                .Where(x => x.Name == employeeName)
                .Select(x => new
                {
                    Name = x.Name,
                    Orders = x.Orders.Where(o => o.Type == Enum.Parse<OrderType>(orderType))
                    .Select(o => new
                    {
                        Customer = o.Customer,
                        Items = o.OrderItems.Select(oi => new
                        {
                            Name = oi.Item.Name,
                            Price = oi.Item.Price,
                            Quantity = oi.Quantity
                        }).ToArray(),
                        TotalPrice = o.TotalPrice
                    })
                    .OrderByDescending(o => o.TotalPrice)
                    .ThenBy(z => z.Items.Length)
                    .ToArray(),
                    TotalMade = x.Orders
                       .Where(s => s.Type == Enum.Parse<OrderType>(orderType))
                       .Sum(z => z.TotalPrice)
                }).FirstOrDefault();

            string jsonEmployee = JsonConvert.SerializeObject(employee, new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented
            });

            return jsonEmployee;
        }

        public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
        {
            
            string[] categoriesArray = categoriesString.Split(',');

            var categories = context.Categories
                    .Where(x => categoriesArray.Any(s => s == x.Name))
                    .Select(s => new CategoryDto
                    {
                        Name = s.Name,
                        MostPopularItem = s.Items.Select(z => new MostPopularItemDto
                        {
                            Name = z.Name,
                            TimesSold = z.OrderItems.Sum(x => x.Quantity),
                            TotalMade = z.OrderItems.Sum(x => x.Item.Price * x.Quantity)
                        })
                        .OrderByDescending(x => x.TotalMade)
                        .ThenBy(q => q.TimesSold)
                        .FirstOrDefault()
                    })
                    .OrderByDescending(x => x.MostPopularItem.TotalMade)
                    .ThenByDescending(x => x.MostPopularItem.TimesSold)
                    .ToArray();


            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("Categories"));

            serializer.Serialize(new StringWriter(sb), categories, xmlNamespaces);

            return sb.ToString();
        }
    }
}