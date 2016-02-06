//  http://www.geeksforgeeks.org/inorder-non-threaded-binary-tree-traversal-without-recursion-or-stack/
//
//  Can we do inorder traversal without threads if we have parent pointers available to us?
//
//

using System;
using System.Collections.Generic;

class Node
{
    public int Val { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    public Node Parent { get; set; }
    
    public override String ToString()
    {
        return String.Format(
                "{0} {1}{2}",
                String.Format("{0}-{1}", Val, Parent == null ? -1 : Parent.Val),
                Left == null ? String.Empty : Left.ToString(),
                Right == null ? String.Empty : Right.ToString());
    }

    public void Parentify()
    {
        if (Left != null)
        {
            Left.Parentify();
            Left.Parent = this;
        }

        if (Right != null)
        {
            Right.Parentify();
            Right.Parent = this;
        }
    }

    public IEnumerable<int> Inorder()
    {
        var current = this;
        Node prev = null;

        while (current != null)
        {
            Node next = null;
            if (prev == current.Parent) // we came down from prev
            {
                if (current.Left != null)
                {
                    next = current.Left;
                }
                else
                {
                    yield return current.Val;
                    next = current.Right == null ? current.Parent : current.Right;
                }
            }
            else if (current.Left == prev) // we're going up
            {
                yield return current.Val;
                next = current.Right == null ? current.Parent : current.Right;
            }
            else
            {
                current = current.Parent;
            }

            prev = current;
            current = next;
        }
    }
}

class Solution
{
    static void Main()
    {
        var root = new Node {
            Val = 10,
            Left = new Node {
                Val = 5
            },
            Right = new Node {
                Val = 100,
                Left = new Node {
                    Val = 80
                },
                Right = new Node {
                    Val = 120
                }
            }
        };

        Console.WriteLine(root);
        root.Parentify();
        Console.WriteLine(root);
        Console.WriteLine(String.Join(", ", root.Inorder()));
    }
}
