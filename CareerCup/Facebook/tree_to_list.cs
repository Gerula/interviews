// http://careercup.com/question?id=6241652616200192
//
// Given a tree, turn it into a list in-place where the right node is the next.
//

using System;
using System.Collections.Generic;

class Node 
{
    public int Val { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public String Preorder()
    {
        return String.Format(
                "{0} {1}{2}",
                Val, 
                Left == null ? String.Empty : Left.Preorder(),
                Right == null ? String.Empty : Right.Preorder());
    }

    public Node Clone()
    {
        return new Node {
            Val = this.Val,
            Left = this.Left == null? null : this.Left.Clone(),
            Right = this.Right == null? null : this.Right.Clone()
        };
    }

    public Node ToList()
    {
        var stack = new Stack<Node>();
        var current = this;
        var root = new Node();
        var previous = root;
        while (current != null || stack.Count > 0)
        {
            if (current == null)
            {
                current = stack.Pop();
                current.Left = null;
                previous.Right = current;
                previous = previous.Right;
                current = current.Right;
            }
            else
            {
                stack.Push(current);
                current = current.Left;
            }
        }

        return root.Right;
    }

    public Node FlattenPre()
    {
        var stack = new Stack<Node>();
        var root = new Node();
        var marker = root;
        stack.Push(this);
        while (stack.Count > 0)
        {
            var current = stack.Pop();
            marker.Left = null;
            marker.Right = current;
            marker = marker.Right;
            if (current.Right != null)
            {
                stack.Push(current.Right);
            }
            if (current.Left != null)
            {
                stack.Push(current.Left);
            }
        }

        return root.Right;
    }

    public Node Flatten()
    {
        var left = this.Left;
        var right = this.Right;
        
        this.Left = null;
        this.Right = null;

        left = left == null ? left : left.Flatten();
        right = right == null ? right : right.Flatten();
        this.Right = left;
        var marker = this;
        while (marker.Right != null)
        {
            marker = marker.Right;
        }

        marker.Right = right;
        return this;
    }
}

class Program
{
    static void Main()
    {
        var node = new Node {
            Val = 1,
            Left = new Node {
                Val = 2,
                Left = new Node {
                    Val = 3
                },
                Right = new Node {
                    Val = 4
                }
            },
            Right = new Node {
                Val = 5,
                Right = new Node {
                    Val = 6
                }
            }
        };

        Console.WriteLine(node.Preorder());

        var ordered = node.Clone();
        Console.WriteLine(ordered.ToList().Preorder());
        var flattened = node.Clone();
        Console.WriteLine(flattened.Flatten().Preorder());
        var flattenedPre = node.Clone();
        Console.WriteLine(flattenedPre.FlattenPre().Preorder());
    }
}
