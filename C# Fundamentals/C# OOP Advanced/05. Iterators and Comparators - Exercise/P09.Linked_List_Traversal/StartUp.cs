namespace P09.Linked_List_Traversal
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            LinkedList<int> linkedList = CreateLinkedList();
            PrintResults(linkedList);
        }

        private static void PrintResults(LinkedList<int> linkedList)
        {
            Console.WriteLine(linkedList.Count);
            foreach (var number in linkedList)
            {
                Console.Write(number + " ");
            }
        }

        private static LinkedList<int> CreateLinkedList()
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            int commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {
                string[] commandInfo = Console.ReadLine().Split();
                string command = commandInfo[0];
                int number = int.Parse(commandInfo[1]);

                switch (command)
                {
                    case "Add":
                        linkedList.Add(number);
                        break;
                    case "Remove":
                        linkedList.Remove(number);
                        break;
                }
            }

            return linkedList;
        }
    }
}
