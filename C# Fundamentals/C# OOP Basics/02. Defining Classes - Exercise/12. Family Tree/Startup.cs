namespace _12.Family_Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Startup
    {
        public static void Main()
        {
            string nameToTrack = Console.ReadLine();
            string input = Console.ReadLine();
            List<string> familyRelations = new List<string>();
            List<Person> relatives = new List<Person>();
            while (!input.Equals("End"))
            {
                if (input.Contains(" - "))
                {
                    familyRelations.Add(input);
                }
                else
                {
                    string[] familyMembersInfo = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string fullName = string.Concat(familyMembersInfo[0]," ", familyMembersInfo[1]);
                    string birthdate = familyMembersInfo[2];

                    Person person = new Person(fullName, birthdate);
                    relatives.Add(person);
                }

                input = Console.ReadLine();
            }

        
            foreach (var relation in familyRelations)
            {
                
                string[] args = relation.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                string nameOrDateParent = args[0];
                Person searchedParent = relatives.Where(r => r.Name == nameOrDateParent || r.Birthday==nameOrDateParent).First();
                Parent parent = new Parent();
                parent.Name = searchedParent.Name;
                parent.Birthday = searchedParent.Birthday;

                string nameOrDateChild = args[1];
                Person searchedChild = relatives.Where(r => r.Name == nameOrDateChild || r.Birthday == nameOrDateChild).First();
                Child child = new Child();
                child.Name = searchedChild.Name;
                child.Birthday = searchedChild.Birthday;

                searchedParent.Children.Add(child);
                searchedChild.Parents.Add(parent);
            }

            Person personToDisplay = relatives.Where(r => r.Name == nameToTrack || r.Birthday==nameToTrack).First();
            Console.WriteLine(personToDisplay.ToString());
        }
    }
}
