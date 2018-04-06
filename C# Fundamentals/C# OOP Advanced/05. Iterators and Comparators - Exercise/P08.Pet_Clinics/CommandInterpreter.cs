namespace P08.Pet_Clinics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommandInterpreter
    {
        private List<Pet> pets;
        private List<Clinic> clinics;

        public CommandInterpreter()
        {
            pets = new List<Pet>();
            clinics = new List<Clinic>();
        }
        public void CreatePet(string name, int age, string kind)
        {
            Pet pet = new Pet(name, age, kind);
            pets.Add(pet);
        }

        public void CreateClinic(string name, int rooms)
        {
            Clinic clinic = new Clinic(name, rooms);
            clinics.Add(clinic);
        }

        public bool Add(string petName, string clinicName)
        {
            Pet searchedPet = this.pets.First(p => p.Name == petName);
            Clinic clinic = clinics.First(c => c.Name == clinicName);
            bool hasPetBeenAdded=clinic.AddPet(searchedPet);

            return hasPetBeenAdded;
        }

        public bool Release(string clinicName)
        {           
            Clinic clinic = clinics.First(c => c.Name == clinicName);
            bool hasPetBeenReleased = clinic.Release();

            return hasPetBeenReleased;
        }

        public bool HasEmptyRooms(string clinicName)
        {
            Clinic clinic = clinics.First(c => c.Name == clinicName);
            bool hasAnyEmptyRooms = clinic.CheckForEmptyRooms();

            return hasAnyEmptyRooms;
        }
        public void Print(string clinicName)
        {
            Clinic clinic = clinics.First(c => c.Name == clinicName);
            string output = clinic.CollectRoomsInfo();

            Console.WriteLine(output);
        }

        public void Print(string clinicName, int room)
        {
            Clinic clinic = clinics.First(c => c.Name == clinicName);
            string output = clinic.CollectRoomInfo(room);

            Console.WriteLine(output);
        }
    }
}
