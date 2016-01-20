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

    public List<int> Longest()
    {
        var result = new List<int>();
        Longest(ref result);
        return result;
    }

    private List<int> Longest(ref List<int> longest)
    {
        var current = new List<int> { Val };
        if (Left == null && Right == null)
        {
            return current;
        }
        
        var leftLongest = Left != null ? Left.Longest(ref longest) : Enumerable.Empty<int>();
        var rightLongest = Right != null ? Right.Longest(ref longest) : Enumerable.Empty<int>();
        
        var localLongest = current;
        if (leftLongest.Any() && Math.Abs(Left.Val - Val) == 1)
        {
            leftLongest = leftLongest.Concat(current).ToList();
            localLongest = leftLongest.ToList();
        }

        if (rightLongest.Any() && Math.Abs(Right.Val - Val) == 1)
        {
            if (Right != null && Math.Abs(Right.Val - Left.Val) == 2)
            {
                localLongest = localLongest.Concat(rightLongest).ToList();
            }

            rightLongest = rightLongest.Concat(current).ToList();
        }

        Console.WriteLine("{0} Left= {1} local= {2}", Val, String.Join(", ", leftLongest), String.Join(", ", localLongest));
        longest = longest.Count() < localLongest.Count() ? localLongest : longest;
        return leftLongest.Count() > rightLongest.Count() ? leftLongest.ToList() : rightLongest.ToList();
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
            Console.WriteLine();
        }
    }
}
