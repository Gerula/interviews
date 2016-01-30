//  http://www.geeksforgeeks.org/check-if-leaf-traversal-of-two-binary-trees-is-same/
//
//  Leaf traversal is sequence of leaves traversed from left to right.
//  The problem is to check if leaf traversals of two given Binary Trees are same or not.
//
//  Expected time complexity O(n). Expected auxiliary space O(h1 + h2) where h1 and h2 are heights of two Binary Trees.

using System;
using System.Collections.Generic;

class Node
{
    public int Val { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(int val, Node left = null, Node right = null)
    {
        val = Val;
        Left = left;
        Right = right;
    }

    public IEnumerable<int> Leaves()
    {
        if (Left == Right && Left == null)
        {
            yield return Val;
        }

        if (Left != null)
        {
            foreach (var leaf in Left.Leaves())
            {
                yield return leaf;
            }
        }

        if (Right != null)
        {
            foreach (var leaf in Right.Leaves())
            {
                yield return leaf;
            }
        }
    }

    public static bool SameLeaves(Node root1, Node root2)
    {
        var first = root1.Leaves().GetEnumerator();
        var second = root2.Leaves().GetEnumerator();
        while (first.MoveNext())
        {
            if (!second.MoveNext() || first.Current != second.Current)
            {
                return false;
            }
        }

        return !second.MoveNext();
    }
}

class Program {
    static void Main()
    {
        var tree1 = new Node(1,
                            new Node(2,
                                     new Node(4)),
                            new Node(3,
                                     new Node(6),
                                     new Node(7)));
        var tree2 = new Node(0,
                            new Node(5,
                                     null,
                                     new Node(4)),
                            new Node(14,
                                     new Node(6),
                                     new Node(7)));
        var tree3 = new Node(0,
                            new Node(5,
                                     null,
                                     new Node(4)),
                            new Node(14,
                                     new Node(6)));
        Console.WriteLine(Node.SameLeaves(tree1, tree2));
        Console.WriteLine(Node.SameLeaves(tree1, tree3));
    }
}
