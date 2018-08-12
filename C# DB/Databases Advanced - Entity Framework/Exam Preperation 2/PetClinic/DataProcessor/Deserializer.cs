namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using global::DataProcessor.Dto.Export;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.Dto.Import;
    using PetClinic.Models;

    public class Deserializer
    {
        private const string errorMessage = "Error: Invalid data.";
        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var deserializedEntities = JsonConvert.DeserializeObject<AnimalAid[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            List<AnimalAid> animalAids = new List<AnimalAid>();

            foreach (var entity in deserializedEntities)
            {
                if (!IsValid(entity))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }
                if (animalAids.Any(aa => aa.Name == entity.Name) ||
                    context.AnimalAids.Any(aa => aa.Name == entity.Name))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }
                animalAids.Add(entity);
                sb.AppendLine($"Record {entity.Name} successfully imported.");
            }
            context.AnimalAids.AddRange(animalAids);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var deserializedEntities = JsonConvert.DeserializeObject<AnimalDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            List<Animal> animals = new List<Animal>();

            foreach (var entity in deserializedEntities)
            {
                if (!IsValid(entity) || !IsValid(entity.Passport))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }
                if (animals.Any(a => a.Passport.SerialNumber == entity.Passport.SerialNumber)
                    || context.Animals.Any(a => a.Passport.SerialNumber == entity.Passport.SerialNumber))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }
                var passport = new Passport
                {
                    SerialNumber = entity.Passport.SerialNumber,
                    OwnerName = entity.Passport.OwnerName,
                    OwnerPhoneNumber = entity.Passport.OwnerPhoneNumber,
                    RegistrationDate = DateTime.ParseExact(entity.Passport.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)
                };

                var animal = new Animal
                {
                    Name = entity.Name,
                    Type = entity.Type,
                    Age = entity.Age,
                    Passport = passport
                };
                animals.Add(animal);
                sb.AppendLine($"Record {animal.Name} Passport №: {passport.SerialNumber} successfully imported.");
            }
            context.Animals.AddRange(animals);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(VetDto[]), new XmlRootAttribute("Vets"));
            var deserializedEntities = (VetDto[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            List<Vet> vets = new List<Vet>();

            foreach (var entity in deserializedEntities)
            {
                if (!IsValid(entity))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }
                if (vets.Any(v => v.PhoneNumber == entity.PhoneNumber) ||
                    context.Vets.Any(v => v.PhoneNumber == entity.PhoneNumber))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }
                var vet = new Vet
                {
                    Name = entity.Name,
                    Profession = entity.Profession,
                    Age = entity.Age,
                    PhoneNumber = entity.PhoneNumber
                };

                vets.Add(vet);
                sb.AppendLine($"Record {vet.Name} successfully imported.");
            }
            context.Vets.AddRange(vets);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ProcedureDto[]), new XmlRootAttribute("Procedures"));
            var deserializedEntities = (ProcedureDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Procedure> validProcedures = new List<Procedure>();
            StringBuilder sb = new StringBuilder();

            foreach (var procedureDto in deserializedEntities)
            {
                var vetObj = context.Vets.FirstOrDefault(v => v.Name == procedureDto.Vet);
                var animalObj = context.Animals.FirstOrDefault(a => a.PassportSerialNumber == procedureDto.Animal);
                List<ProcedureAnimalAid> validProcedureAnimalAids = new List<ProcedureAnimalAid>();
                bool allAidsExist = true;

                foreach (var procedureDtoAnimalAid in procedureDto.AnimalAids)
                {
                    var animalAid = context.AnimalAids
                        .FirstOrDefault(ai => ai.Name == procedureDtoAnimalAid.Name);

                    if (animalAid == null || validProcedureAnimalAids.Any(p=>p.AnimalAid.Name==procedureDtoAnimalAid.Name))
                    {
                        allAidsExist = false;
                        break;
                    }

                    var animalAidProcedure = new ProcedureAnimalAid()
                    {
                        AnimalAid = animalAid
                    };

                    validProcedureAnimalAids.Add(animalAidProcedure);
                }
                if (!IsValid(procedureDto)
                    || !procedureDto.AnimalAids.All(IsValid)
                    || animalObj==null
                    ||!allAidsExist
                    || vetObj==null)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }
                var proc = new Procedure
                {
                    Animal = animalObj,
                    Vet = vetObj,
                    DateTime = DateTime.ParseExact(procedureDto.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ProcedureAnimalAids=validProcedureAnimalAids
                };

                validProcedures.Add(proc);
                sb.AppendLine("Record successfully imported.");
            }

            context.Procedures.AddRange(validProcedures);
            context.SaveChanges();

            var result = sb.ToString();
            return result;        
        }


        private static bool IsValid(object entity)
        {
            var context = new ValidationContext(entity);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(entity, context, results, true);
        }
    }
}
