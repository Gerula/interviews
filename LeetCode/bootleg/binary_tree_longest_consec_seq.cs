//  http://lcoj.tk/problems/binary-tree-longest-consecutive-sequencesummer-liu-in_review/
//
//  Given a binary tree, find the length of the longest consecutive sequence path.
//
//  The path refers to any sequence of nodes from some starting node to any node in the tree along the parent-child connections.
//  The longest consecutive path need to be from parent to child (cannot be the reverse).

using System;
using System.Collections.Generic;
using System.Linq;

class Node 
{
    public int Val { get; set; }
    public Node Left { get; set ; }
    public Node Right { get; set ; }

    public IEnumerable<int> Longest()
    {
        var current = new [] { Val };
        if (Left == null && Right == null)
        {
            return current;
        }

        IEnumerable<int> maxLeft = new int[0];
        if (Left != null)
        {
            maxLeft = Left.Val + 1 == Val ? Left.Longest().Concat(current) : Left.Longest();
        }

        IEnumerable<int> maxRight = new int[0];
        if (Right != null)
        {
            maxRight = Right.Val + 1 == Val ? Right.Longest().Concat(current) : Right.Longest();
        }

        var maxChildren = maxLeft.Count() > maxRight.Count() ? maxLeft : maxRight;
        if (maxChildren.Count() > 1)
        {
            return maxChildren;
        }

        return current;
    }
}

class Solution
{
    static void Main()
    {
        foreach (var root in new [] { 
                    new Node { 
                        Val = 4,
                        Left = new Node {
                            Val = 1
                        },
                        Right = new Node {
                            Val = 3,
                            Left = new Node {
                                Val = 2
                            },
                            Right = new Node {
                                Val = 5
                            }
                        }
                    },
                    new Node {
                        Val = 5,
                        Left = new Node {
                            Val = 2
                        },
                        Right = new Node {
                            Val = 3,
                            Left = new Node {
                                Val = 2,
                                Left = new Node {
                                    Val = 3
                                },
                                Right = new Node {
                                    Val = 1
                                }
                            },
                            Right = new Node {
                                Val = 4
                            }
                        }
                    }
                })
        {
            Console.WriteLine(String.Join(", ", root.Longest()));
        }
    }
}
