namespace _09.CollectionHierarchy
{
    using _09.CollectionHierarchy.Classes;
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            List<IRemovable> collections = AddIntoCollections();
            RemoveElementsFromCollections(collections);
          
        }

        private static void RemoveElementsFromCollections(List<IRemovable> collectionsToRemove)
        {
            int removeOperatons = int.Parse(Console.ReadLine());
            List<string> removed = new List<string>();

            foreach (var collection in collectionsToRemove)
            {
                for (int operation = 0; operation < removeOperatons; operation++)
                {
                    removed.Add(collection.Remove());                   
                }
                Console.WriteLine(string.Join(" ", removed));
                removed.Clear();
            }
           
        }

        private static List<IRemovable> AddIntoCollections()
        {
            string[] elementsToAdd = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<IAddible> collections = new List<IAddible>();
            List<IRemovable> collectionsToRemove = new List<IRemovable>();

            collections.Add(new AddCollection());
            collections.Add(new AddRemoveCollection());
            collections.Add(new MyList());
            List<int> added = new List<int>();

            foreach (var collection in collections)
            {
                for (int index = 0; index < elementsToAdd.Length; index++)
                {
                    added.Add(collection.Add(elementsToAdd[index]));
                }
                Console.WriteLine(string.Join(" ", added));
                added.Clear();
            }

            collectionsToRemove.Add(new AddRemoveCollection());
            collectionsToRemove.Add(new MyList());

            foreach (var collection in collectionsToRemove)
            {
                for (int index = 0; index < elementsToAdd.Length; index++)
                {
                    collection.Add(elementsToAdd[index]);
                }
            }         
           
            return collectionsToRemove;
        }
    }
}
