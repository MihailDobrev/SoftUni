namespace _10.ExplicitInterfaces
{
    using System;
    public class Startup
    {
        public static void Main()
        {
            PrintCitizenNames();
        }

        private static void PrintCitizenNames()
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] citizenInfo = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                ICitizen citizen = new Citizen(citizenInfo[0], citizenInfo[1], int.Parse(citizenInfo[2]));
                IPerson person = citizen as IPerson;
                Console.WriteLine(person.GetName());
                IResident resident = citizen as IResident;
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
