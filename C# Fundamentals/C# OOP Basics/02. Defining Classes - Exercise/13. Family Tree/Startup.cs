namespace _13.Family_Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Startup
    {
        public static void Main()
        {
            string searchedPerson = Console.ReadLine();
            List<Person> relatives = new List<Person>();
            Queue<string> familyRelations = new Queue<string>();

            string familyTreeInfo;
            while ((familyTreeInfo = Console.ReadLine()) != "End")
            {
                if (familyTreeInfo.Contains('-'))
                {
                    familyRelations.Enqueue(familyTreeInfo);
                }
                else
                {
                    string[] relativesInfo = familyTreeInfo.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    relatives.Add(new Person($"{relativesInfo[0]} {relativesInfo[1]}", relativesInfo[2]));
                }
            }

            relatives = AddRelativesToEveryPerson(relatives, familyRelations);

            PrintSearchedPerson(relatives, searchedPerson);
        }

        private static List<Person> AddRelativesToEveryPerson(List<Person> relatives, Queue<string> familyRelations)
        {
            while (familyRelations.Count > 0)
            {
                string[] familyRelationInfo = familyRelations.Dequeue().Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                Person parent;

                if (familyRelationInfo[0].Contains("/"))
                {
                    parent = relatives.FirstOrDefault(r => r.BirthDate == familyRelationInfo[0]);

                }
                else
                {
                    parent = relatives.FirstOrDefault(r => r.FullName == familyRelationInfo[0]);
                }

                Person child;

                if (familyRelationInfo[1].Contains("/"))
                {
                    child = relatives.FirstOrDefault(r => r.BirthDate == familyRelationInfo[1]);
                }
                else
                {
                    child = relatives.FirstOrDefault(r => r.FullName == familyRelationInfo[1]);
                }

                child.Parents[parent.FullName] = parent.BirthDate;
                parent.Children[child.FullName] = child.BirthDate;
            }

            return relatives;
        }

        private static void PrintSearchedPerson(List<Person> relatives, string searchedPerson)
        {
            Person person = relatives.FirstOrDefault(p => p.FullName == searchedPerson);
            if (person == null)
            {
                person = relatives.FirstOrDefault(p => p.BirthDate == searchedPerson);
            }

            Console.Write(person.ToString());
        }
    }
}
