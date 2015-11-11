// http://www.geeksforgeeks.org/find-count-of-singly-subtrees/
//
// Given a binary tree, write a program to count the number of Single Valued Subtrees.
// A Single Valued Subtree is one in which all the nodes have same value.
// Expected time complexity is O(n).
//

using System;

class Node 
{
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Tuple<bool, int> CountSingleSubTrees()
    {
        var left = Left == null ? Tuple.Create(true, 0) : Left.CountSingleSubTrees();
        var right = Right == null ? Tuple.Create(true, 0) : Right.CountSingleSubTrees();
        var isThisSingle = left.Item1 && right.Item1 && 
                           (Left == null || Value == Left.Value) &&
                           (Right == null || Value == Right.Value);

        return Tuple.Create(isThisSingle, left.Item2 + right.Item2 + (isThisSingle ? 1 : 0));
    }
}

class Program 
{
    static void Main()
    {
        Console.WriteLine(new Node {
                Value = 5,
                Left = new Node {
                    Value = 1,
                    Left = new Node {
                        Value = 5
                    },
                    Right = new Node {
                        Value = 5
                    }
                },
                Right = new Node {
                    Value = 5,
                    Right = new Node {
                        Value = 5
                    }
                }
            }.
            CountSingleSubTrees().
            Item2);

        Console.WriteLine(new Node {
                Value = 5,
                Left = new Node {
                    Value = 4,
                    Left = new Node {
                        Value = 4
                    },
                    Right = new Node {
                        Value = 4
                    }
                },
                Right = new Node {
                    Value = 5,
                    Right = new Node {
                        Value = 5
                    }
                }
            }.
            CountSingleSubTrees().
            Item2);
    }
}
