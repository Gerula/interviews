// http://careercup.com/question?id=5086938656669696
//
// Given two trees, return true if they have the same inorder
//

using System;
using System.Collections.Generic;
using System.Linq;

class Node
{
    public int Val { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public IEnumerable<int> Inorder()
    {
        if (Left != null)
        {
            foreach (var node in Left.Inorder())
            {
                yield return node;
            }
        }

        yield return this.Val;

        if (Right != null)
        {
            foreach (var node in Right.Inorder())
            {
                yield return node;
            }
        }
    }

    public bool SameInorder(Node other)
    {
        var first = this.Inorder().GetEnumerator();
        var second = other.Inorder().GetEnumerator();
        
        while (first.MoveNext() && second.MoveNext() &&
               first.Current == second.Current)
        {
        }

        return !(first.MoveNext() || second.MoveNext());
    }
}

static class Program
{
    static void Main()
    {
        var tree1 = new Node {
            Val = 1,
            Left = new Node {
                Val = 4,
                Left = new Node {
                    Val = 3
                },
                Right = new Node {
                    Val = 2
                }
            },
            Right = new Node {
                Val = 5 
            }
        };

        var tree2 = new Node {
            Val = 2,
            Left = new Node {
                Val = 4,
                Left = new Node {
                    Val = 3
                }
            },
            Right = new Node {
                Val = 5, 
                Left = new Node {
                    Val = 1    
                }
            }
        };

        Console.WriteLine(tree1.SameInorder(tree2));
        Console.WriteLine(String.Join(", ", tree1.Inorder()));
        Console.WriteLine(String.Join(", ", tree2.Inorder()));
        tree2.Left = null;
        Console.WriteLine(tree1.SameInorder(tree2));
        Console.WriteLine(String.Join(", ", tree1.Inorder()));
        Console.WriteLine(String.Join(", ", tree2.Inorder()));
    }
}

