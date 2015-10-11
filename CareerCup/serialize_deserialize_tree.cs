// http://careercup.com/question?id=5163236590616576
//
// Given a tree how would you write it to disk so it can be
// moved to another machine and recreated?
//

using System;
using System.Collections.Generic;

class Node
{
    internal int Value { get; set; }
    internal Node Left { get; set; }
    internal Node Right { get; set; }

    internal static bool Equals(Node a, Node b)
    {
        if (a == null || b == null)
        {
            return a == null && b == null;
        }

        return a.Value == b.Value &&
               Equals(a.Left, b.Left) &&
               Equals(a.Right, b.Right);
    }
}

static class Program 
{
    static Node Deserialize(this List<int?> a)
    {
        Stack<Node> stack = new Stack<Node>();
        var reversed = new List<int?>(a);
        reversed.Reverse();
        foreach (var node in reversed)
        {
            if (!node.HasValue)
            {
                stack.Push(null);
            }
            else
            {
                stack.Push(new Node {
                        Value = node.Value,
                        Left = stack.Pop(),
                        Right = stack.Pop()
                      });
            }
        }

        return stack.Pop();
    }

    static List<int?> Serialize(this Node node)
    {
        List<int?> result = new List<int?>();
        Stack<Node> stack = new Stack<Node>();
        stack.Push(node);

        while (stack.Count != 0)
        {
            Node current = stack.Pop();
            if (current == null)
            {
                result.Add(null);
            }
            else
            {
                result.Add(current.Value);
                stack.Push(current.Right);
                stack.Push(current.Left);
            }
        }

        return result;
    }

    static void Main()
    {
        Node root = new Node {
            Value = 3,
            Left = new Node {
                Value = 2,
                Left = new Node {
                    Value = 1,
                    Left = null,
                    Right = null
                },
                Right = null
            },
            Right = new Node {
                Value = 7,
                Left = null,
                Right = new Node {
                    Value = 8,
                    Left = null,
                    Right = new Node {
                        Value = 10,
                        Left = null,
                        Right = null
                    }
                }
            }
        };

        if (!Node.Equals(root, root.Serialize().Deserialize()))
        {
            throw new Exception("Not good enough");
        }

        Console.WriteLine("All appears to be well.");
    }
}
