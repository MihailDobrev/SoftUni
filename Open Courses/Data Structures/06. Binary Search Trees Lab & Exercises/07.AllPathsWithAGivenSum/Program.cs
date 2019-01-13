using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.AllPathsWithAGivenSum
{
    public class Program
    {
        private static Dictionary<int, Tree<int>> tree = new Dictionary<int, Tree<int>>();

        public static void Main()
        {
            ReadTree();
            int sum = ReadSum();
            Tree<int> root = GetRootNode();
            List<List<int>> paths = root.GetAllPaths();
            string allPaths = GetAllPathsWithAGivenSumInString(paths, sum);
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
                    path.Reverse();
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
            Console.WriteLine($"Paths of sum {sum}: {allPaths}");
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

        public List<List<T>> GetAllPaths()
        {
            List<List<T>> paths = new List<List<T>>();
            FillAllPaths(this, paths);

            return paths;
        }

        private void FillAllPaths(Tree<T> tree, List<List<T>> nodes)
        {
            if (tree.Children.Count == 0)
            {
                nodes.Add(new List<T>() { });
                FillPreviousNodes(nodes, tree);
            }

            foreach (var child in tree.Children)
            {
                FillAllPaths(child, nodes);
            }
        }

        private void FillPreviousNodes(List<List<T>> nodes, Tree<T> tree)
        {
            nodes[nodes.Count - 1].Add(tree.Value);

            if (tree.Parent != null)
            {
                FillPreviousNodes(nodes, tree.Parent);
            }

        }
    }
}
