namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string errorMessage = "Invalid Data";
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var deserializedEntities = JsonConvert.DeserializeObject<Department[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            List<Department> validDepartments = new List<Department>();

            foreach (var department in deserializedEntities)
            {
                bool cellNumberInvalid = false;

                foreach (var cell in department.Cells)
                {
                    if (!IsValid(cell))
                    {
                        cellNumberInvalid = true;
                        break;
                    }
                }

                if (!IsValid(department) || cellNumberInvalid)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }
                validDepartments.Add(department);
                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.Departments.AddRange(validDepartments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var deserializedEntities = JsonConvert.DeserializeObject<PrisonerDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            List<Prisoner> validPrisoners = new List<Prisoner>();

            foreach (var entity in deserializedEntities)
            {
                bool mailIsInvalid = false;
                List<Mail> validMails = new List<Mail>();

                foreach (var mailDto in entity.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        mailIsInvalid = true;
                        break;
                    }
                    var mailObj = new Mail
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address
                    };
                    validMails.Add(mailObj);
                }

                if (!IsValid(entity) || mailIsInvalid)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }
                var prisoner = new Prisoner
                {
                    FullName = entity.FullName,
                    Nickname = entity.Nickname,
                    Age = entity.Age,
                    IncarcerationDate = DateTime.ParseExact(entity.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ReleaseDate = entity.ReleaseDate == null ? (DateTime?)null : DateTime.ParseExact(entity.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Bail = entity.Bail,
                    CellId = entity.CellId,
                    Mails = validMails
                };
                validPrisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(OfficerDto[]), new XmlRootAttribute("Officers"));
            var deserializedEntities = (OfficerDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Officer> validOfficers = new List<Officer>();
            StringBuilder sb = new StringBuilder();

            foreach (var entity in deserializedEntities)
            {
                List<OfficerPrisoner> validOfficerPrisoners = new List<OfficerPrisoner>();

                foreach (var prisonerDto in entity.Prisoners)
                {
                    var officerPrisoner = new OfficerPrisoner()
                    {
                        PrisonerId = prisonerDto.Id
                    };
                    validOfficerPrisoners.Add(officerPrisoner);
                }

                bool positionFound = Enum.TryParse<Position>(entity.Position, out Position position);
                bool weaponFound = Enum.TryParse<Weapon>(entity.Weapon, out Weapon weapon);

                if (!IsValid(entity)
                   || !entity.Prisoners.All(IsValid)
                   || !positionFound
                   || !weaponFound)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                var officer = new Officer
                {
                    FullName = entity.FullName,
                    Salary = entity.Salary,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = entity.DepartmentId,
                    OfficerPrisoners = validOfficerPrisoners
                };

                validOfficers.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(validOfficers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object entity)
        {
            var context = new ValidationContext(entity);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(entity, context, results, true);
        }
    }
}