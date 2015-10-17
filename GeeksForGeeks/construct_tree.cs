// http://www.geeksforgeeks.org/construct-a-binary-tree-from-parent-array-representation/
//
// Given an array that represents a tree in such a way array indexes are values
// in tree nodes array values give the parent node of that particular index (or node).
// The value of the root node index would always be -1 as there is no parent for root.
// Construct the standard linked representation of given Binary Tree from this given representation.

using System;

class Node
{
    public int Value { get; set; }
    public Node Left { get; set ;}
    public Node Right { get; set ;}

    public override String ToString()
    {
        return String.Format(
                "{0} {1}{2}", 
                Left == null? String.Empty : Left.ToString(),
                Value,
                Right == null? String.Empty : Right.ToString());
    }
}

static class Program 
{
    static Node ToTree(this int[] a)
    {
        Node[] nodes = new Node[a.Length];
        Node root = null;

        for (int i = 0; i < a.Length; i++)
        {
            if (nodes[i] != null)
            {
                continue;
            }

            nodes[i] = new Node { Value = i };
            int k = a[i];
            Node prev = nodes[i];
            while (k < a.Length &&
                    k != - 1 &&
                    (nodes[k] == null ||
                     nodes[k].Left == null ||
                     nodes[k].Right == null))
            {
                if (nodes[k] == null)
                {
                    nodes[k] = new Node { Value = k };
                }

                Node node = nodes[k];

                if (node.Left == null) 
                {
                    node.Left = prev;
                }
                else 
                {
                    node.Right = prev;
                }

                if (a[k] == -1)
                {
                    root = node;
                }

                k = a[k];
                prev = node;
            }
        }

        return root;
    }
    
    static void Main()
    {
        Console.WriteLine(new [] {1, 5, 5, 2, 2, -1, 3}.ToTree());
    }
}
