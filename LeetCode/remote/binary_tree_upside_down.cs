//  This one don't got no url as it's bootlegged :)
//
//  Given a binary tree where all the right nodes are either leaf nodes with a sibling
//  (a left node that shares the same parent node) or empty,
//  flip it upside down and turn it into a tree where the original right nodes turned into left leaf nodes. Return the new root.

using System;

class Node
{
    public int Val;
    public Node Left;
    public Node Right;

    public override String ToString()
    {
        return String.Format(
                "{0} {1} {2}",
                Val,
                Left == null ? "#" : Left.ToString(),
                Right == null ? "#" : Right.ToString());
    }

    public static Node Australia(Node root)
    {
        if (root == null)
        {
            return root;
        }

        var left = root.Left;
        var right = root.Right;
        var newRoot = Australia(left);
        if (newRoot != null)
        {
            left.Right = root;
            left.Left = right;
        }

        root.Left = null;
        root.Right = null;
        if (newRoot != null)
        {
            return newRoot;
        }

        return root;
    }

    static void Main()
    {
        var root = new Node {
            Val = 1,
            Left = new Node {
                Val = 2,
                Left = new Node {
                    Val = 4
                },
                Right = new Node {
                    Val = 5
                }
            },
            Right = new Node {
                Val = 3
            }
        };

        Console.WriteLine(root);
        Console.WriteLine(Australia(root));
    }
}


