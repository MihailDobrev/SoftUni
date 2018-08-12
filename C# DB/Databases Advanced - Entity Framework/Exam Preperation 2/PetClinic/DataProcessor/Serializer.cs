namespace PetClinic.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.Dto.Export;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var animals = context.Animals.Where(a => a.Passport.OwnerPhoneNumber == phoneNumber);

            var animalArray = animals.Select(a => new
            {
                OwnerName = a.Passport.OwnerName,
                AnimalName = a.Name,
                Age = a.Age,
                SerialNumber = a.Passport.SerialNumber,
                RegisteredOn = a.Passport.RegistrationDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
            })
            .OrderBy(a=>a.Age)
            .ThenBy(a=>a.SerialNumber)
            .ToArray();

            var jsonAnimals = JsonConvert.SerializeObject(animalArray, new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented
            });
            return jsonAnimals;
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var procedures = context.Procedures
                .Select(p => new ExportProcedureDto
                {
                    Passport = p.Animal.Passport.SerialNumber,
                    OwnerNumber = p.Animal.Passport.OwnerPhoneNumber,
                    DateTime = p.DateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    AnimalAids = p.ProcedureAnimalAids.Select(paa => new ExportAnimalAidDto
                    {
                        Name = paa.AnimalAid.Name,
                        Price = paa.AnimalAid.Price
                    }).ToArray(),
                    TotalPrice=p.ProcedureAnimalAids.Sum(ai=>ai.AnimalAid.Price)
                })
                .OrderBy(x => DateTime.ParseExact(x.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                .ThenBy(y => y.Passport)
                .ToArray();
            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(typeof(ExportProcedureDto[]), new XmlRootAttribute("Procedures"));

            serializer.Serialize(new StringWriter(sb), procedures, xmlNamespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
