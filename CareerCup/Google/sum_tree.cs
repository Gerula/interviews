// http://careercup.com/question?id=6386292369653760
//
// Given a BST and a number X, find out if there are two nodes
// in the tree that sum up to X.
//

using System;
using System.Collections.Generic;
using System.Linq;

class Node 
{
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public IEnumerable<Node> Inorder(bool isReversed)
    {
        Node first = isReversed ? this.Right : this.Left;
        Node second = isReversed ? this.Left : this.Right;

        if (first != null)
        {
            foreach (var node in first.Inorder(isReversed))
            {
                yield return node;
            }
        }

        yield return this;

        if (second != null)
        {
            foreach (var node in second.Inorder(isReversed))
            {
                yield return node;
            }
        }
    }

    public override String ToString()
    {
        return this.Value.ToString();
    }
}

static class Program
{
    static Tuple<int, int> GetSum(this Node tree, int sum)
    {
        return Tuple.Create(0, 0);
    }

    static void Main()
    {
        var tree = new Node {
            Value = 5,
            Left = new Node {
                Value = 3,
                Left = new Node {
                    Value = 2
                },
                Right = new Node {
                    Value = 4
                }
            },
            Right = new Node {
                Value = 8,
                Left = new Node {
                    Value = 6,
                    Right = new Node {
                        Value = 7
                    }
                }
            }
        };

        Console.WriteLine(String.Join(", ", tree.Inorder(false)));
        Console.WriteLine(String.Join(", ", tree.Inorder(true)));

        Console.WriteLine(String.Join(
                                        Environment.NewLine, 
                                        Enumerable.
                                            Range(1, 10).
                                            Select(x => String.Format("{0} - {1}", x, tree.GetSum(x)))));
                                                
    }
}
