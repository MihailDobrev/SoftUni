﻿namespace _06.BirthdayCelebrations
{
    public class Citizen : IIdentifiable,IBirthDate
    {
        public Citizen(string name, int age, string id, string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }

        public string BirthDate { get; set; }

    }
}
