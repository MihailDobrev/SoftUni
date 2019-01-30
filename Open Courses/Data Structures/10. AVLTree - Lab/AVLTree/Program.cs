using System;

class Program
{
    static void Main(string[] args)
    {
        AVL<int> tree = new AVL<int>();
        tree.Insert(8);
        tree.Insert(4);
        tree.Insert(3);
        tree.Insert(1);
        tree.Insert(9);
        tree.Insert(7);
    }
}
