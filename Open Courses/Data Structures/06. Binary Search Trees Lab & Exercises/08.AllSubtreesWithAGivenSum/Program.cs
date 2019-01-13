using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.AllSubtreesWithAGivenSum
{
    public class Program
    {
        private static Dictionary<int, Tree<int>> tree = new Dictionary<int, Tree<int>>();

        public static void Main()
        {
            ReadTree();
            int sum = ReadSum();
            Tree<int> root = GetRootNode();
            List<List<int>> subtrees = root.FindAllSubtrees();
            string allPaths = GetAllPathsWithAGivenSumInString(subtrees, sum);
            PrintPaths(allPaths, sum);
        }

        private static string GetAllPathsWithAGivenSumInString(List<List<int>> paths, int givenSum)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();

            foreach (var path in paths)
            {
                int pathSum = 0;

                foreach (var value in path)
                {
                    pathSum += value;
                }

                if (pathSum == givenSum)
                {
                    sb.AppendLine(string.Join(" ", path));
                }

            }

            return sb.ToString().TrimEnd();
        }

        private static int ReadSum()
        {
            return int.Parse(Console.ReadLine());
        }

        private static void PrintPaths(string allPaths, int sum)
        {
            Console.WriteLine($"Subtrees of sum {sum}: {allPaths}");
        }

        private static Tree<int> GetRootNode()
        {
            return tree.Values.FirstOrDefault(x => x.Parent == null);
        }


        private static void ReadTree()
        {
            int numberOfNodes = int.Parse(Console.ReadLine());

            for (int i = 1; i < numberOfNodes; i++)
            {
                int[] nodes = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                AddEdge(nodes);
            }
        }

        private static void AddEdge(int[] nodes)
        {
            int parent = nodes[0];
            int child = nodes[1];

            Tree<int> parentNode = GetTreeNodeByValue(parent);
            Tree<int> childNode = GetTreeNodeByValue(child);

            parentNode.Children.Add(childNode);
            childNode.Parent = parentNode;
        }

        private static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!tree.ContainsKey(value))
            {
                tree.Add(value, new Tree<int>(value));
            }

            return tree[value];
        }
    }
    public class Tree<T>
    {
        public T Value { get; set; }

        public List<Tree<T>> Children { get; set; }

        public Tree<T> Parent { get; set; }

        public Tree(T value, params Tree<T>[] children)
        {
            this.Value = value;
            this.Children = new List<Tree<T>>(children);
        }

        public List<List<T>> FindAllSubtrees()
        {
            List<List<T>> paths = new List<List<T>>();
            FindAllSubtrees(this, paths);

            return paths;
        }

        private void FindAllSubtrees(Tree<T> tree, List<List<T>> nodes)
        {
            if (tree.Parent!=null)
            {
                nodes.Add(new List<T>());
                nodes[nodes.Count - 1].Add(tree.Value);
                AddChildrednValues(tree, nodes);
            }

            foreach (var child in tree.Children)
            {
                FindAllSubtrees(child, nodes);
            }
        }

        private static void AddChildrednValues(Tree<T> tree, List<List<T>> nodes)
        {
            foreach (var child in tree.Children)
            {
                nodes[nodes.Count - 1].Add(child.Value);
                AddChildrednValues(child, nodes);
            }
            
        }
    }
}
