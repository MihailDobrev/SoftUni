namespace _04.Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Startup
    {
        static Dictionary<string, List<string>> doctorsWithPatients = new Dictionary<string, List<string>>();
        static Dictionary<string, List<List<string>>> departmentsWithRooms = new Dictionary<string, List<List<string>>>();
        public static void Main()
        {
            FillDepartmentsAndDoctorsWithData();
            PrintHospitalData();      
        }

        private static void PrintHospitalData()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departmentsWithRooms[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int room))
                {
                    Console.WriteLine(string.Join("\n", departmentsWithRooms[args[0]][room - 1].OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join("\n", doctorsWithPatients[args[0] + args[1]].OrderBy(x => x)));
                }
                command = Console.ReadLine();
            }
        }

        private static void FillDepartmentsAndDoctorsWithData()
        {
            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] tokens = command.Split();
                var department = tokens[0];
                var firstName = tokens[1];
                var secondName = tokens[2];
                var pacient = tokens[3];
                var patientFullName = firstName + secondName;

                if (!doctorsWithPatients.ContainsKey(patientFullName))
                {
                    doctorsWithPatients[patientFullName] = new List<string>();
                }
                if (!departmentsWithRooms.ContainsKey(department))
                {
                    departmentsWithRooms[department] = new List<List<string>>();
                    for (int stai = 0; stai < 20; stai++)
                    {
                        departmentsWithRooms[department].Add(new List<string>());
                    }
                }

                bool hasVacancies = departmentsWithRooms[department].SelectMany(x => x).Count() < 60;
                if (hasVacancies)
                {
                    int room = 0;
                    doctorsWithPatients[patientFullName].Add(pacient);

                    for (int i = 0; i < departmentsWithRooms[department].Count; i++)
                    {
                        if (departmentsWithRooms[department][i].Count < 3)
                        {
                            room = i;
                            break;
                        }
                    }
                    departmentsWithRooms[department][room].Add(pacient);
                }

                command = Console.ReadLine();
            }
        }
    }
}
