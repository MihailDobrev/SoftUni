using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.LongestPath
{
    public class Program
    {
        private static Dictionary<int, Tree<int>> tree = new Dictionary<int, Tree<int>>();

        public static void Main()
        {
            ReadTree();
            Tree<int> root = GetRootNode();
            List<int> longestPath = root.GetLongestPath();
            PrintNodes(longestPath);
        }

        private static void PrintNodes(List<int> longestPath)
        {
            longestPath.Reverse();
            Console.WriteLine($"Longest path: {string.Join(" ", longestPath)}");
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

        public List<T> GetLongestPath()
        {
            List<List<T>> paths = new List<List<T>>();
            FillAllPaths(this, paths);

            int maxLenght = 0;
            List<T> maxPath = new List<T>();

            foreach (var path in paths)
            {
                var pathLenght = path.Count;

                if (pathLenght > maxLenght)
                {
                    maxLenght = pathLenght;
                    maxPath = path;
                }
            }

            return maxPath;
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
