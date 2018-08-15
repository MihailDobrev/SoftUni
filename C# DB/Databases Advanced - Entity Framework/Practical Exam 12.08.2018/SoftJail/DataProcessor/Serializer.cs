namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                 .Where(p => ids.Any(i => i == p.Id))
                 .Select(p => new
                 {
                     Id = p.Id,
                     Name = p.FullName,
                     CellNumber = p.Cell.CellNumber,
                     Officers = p.PrisonerOfficers.Select(po => new
                     {
                         OfficerName = po.Officer.FullName,
                         Department = po.Officer.Department.Name
                     })
                     .OrderBy(o => o.OfficerName)
                     .ToArray(),
                     TotalOfficerSalary = p.PrisonerOfficers.Sum(o => o.Officer.Salary)
                 })
                 .OrderBy(p => p.Name)
                 .ThenBy(p => p.Id)
                 .ToArray();

            var jsonPrisoners = JsonConvert.SerializeObject(prisoners, new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented
            });
            return jsonPrisoners;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] prisonerNamesArray = prisonersNames.Split(',');

            var prisoners = context.Prisoners
                .Where(p => prisonerNamesArray.Any(n => n == p.FullName))
                .OrderBy(p => p.FullName)
                .ThenBy(p => p.Id)
                .Select(p => new PrisonerExportDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = p.Mails
                        .Select
                        (m => new MessageDto
                        {
                            Description = Reversed(m.Description)
                        }).ToArray()
                }).ToArray();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(typeof(PrisonerExportDto[]), new XmlRootAttribute("Prisoners"));

            serializer.Serialize(new StringWriter(sb), prisoners, xmlNamespaces);

            return sb.ToString().TrimEnd();
        }

        private static string Reversed(string description)
        {
            char[] cArray = description.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }
    }
}