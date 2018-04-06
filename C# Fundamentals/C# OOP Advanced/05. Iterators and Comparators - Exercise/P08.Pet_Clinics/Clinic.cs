namespace P08.Pet_Clinics
{
    using System;
    using System.Linq;
    using System.Text;

    public class Clinic
    {
        private int numberOfRooms;
        private Pet[] clinicRooms;

        public Clinic(string name, int numberOfRooms)
        {
            Name = name;
            NumberOfRooms = numberOfRooms;
            clinicRooms = new Pet[this.numberOfRooms];
            for (int i = 0; i < numberOfRooms; i++)
            {
                clinicRooms[i] = null;
            }
        }

        public string Name { get; private set; }
        public int NumberOfRooms
        {
            get { return numberOfRooms; }
            private set
            {
                if (value % 2 == 0)
                {
                    throw new ArgumentException("Invalid Operation!");
                }
                numberOfRooms = value;
            }
        }

        public bool AddPet(Pet pet)
        {
            int startingIndex = this.numberOfRooms / 2;
            bool petFilled = false;

            if (this.clinicRooms.Any(p => p == null))
            {
                int oppositeMovement = 2;
                int originalIndex = 0;

                petFilled=PetFilled(pet, startingIndex);
                if (petFilled)
                {
                    return true;
                }

                for (int index = startingIndex - 1; index >= 0; index--)
                {
                    petFilled = PetFilled(pet, index);
                    if (petFilled)
                    {
                        return true;
                    }
                    originalIndex = index;
                    index += oppositeMovement;
                    petFilled = PetFilled(pet, index);
                    if (petFilled)
                    {
                        return true;
                    }
                    oppositeMovement += 2;
                    index = originalIndex;
                }
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool PetFilled(Pet pet, int index)
        {
            if (this.clinicRooms[index] == null)
            {
                clinicRooms[index] = pet;
                return true;
            }
            return false;
        }

        public bool Release()
        {
            bool petRemoved = false;
            if (this.clinicRooms.Any(p => p != null))
            {
                int startingIndex = this.numberOfRooms / 2;

                for (int index = startingIndex; index < this.clinicRooms.Length; index++)
                {
                    petRemoved=PetHasBeenRemoved(index);
                    if (petRemoved)
                    {
                        return true;
                    }
                }
                for (int index = 0; index < startingIndex; index++)
                {
                    petRemoved = PetHasBeenRemoved(index);
                    if (petRemoved)
                    {
                        return true;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool PetHasBeenRemoved(int index)
        {
            if (this.clinicRooms[index] != null)
            {
                clinicRooms[index] = null;
                return true;
            }
            return false;
        }

        public bool CheckForEmptyRooms()
        {
            if (this.clinicRooms.Any(r => r == null))
            {
                return true;
            }
            return false;
        }

        public string CollectRoomsInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Pet room in clinicRooms)
            {
                if (room == null)
                {
                    sb.AppendLine("Room empty");
                }
                else
                {
                    sb.AppendLine(room.ToString());
                }

            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        public string CollectRoomInfo(int room)
        {
            string roomInfo = string.Empty;
            Pet pet = clinicRooms[room-1];

            if (pet == null)
            {
                roomInfo="Room empty";
            }
            else
            {
                roomInfo= pet.ToString();
            }
            return roomInfo;
        }
    }
}
