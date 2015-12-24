//  http://www.geeksforgeeks.org/diagonal-sum-binary-tree/

using System;
using System.Collections.Generic;
using System.Linq;

class Node
{
    public int Val { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    
    public override String ToString()
    {
        return String.Format(
                "{0} {1} {2}",
                Val,
                Left == null ? "." : Left.ToString(),
                Right == null ? "." : Right.ToString());
    }

    public static IEnumerable<int> GetSums(Node root)
    {
        var mock = new Node();
        var falseLinks = new HashSet<Node>();
        while (root != null)
        {
            var sum = 0;
            var dummy = mock;
            while (root != null)
            {
                sum += root.Val;
                if (root.Left != null)
                {
                    if (dummy.Right == null)
                    {
                        falseLinks.Add(dummy);
                    }

                    dummy.Right = root.Left;
                    dummy = dummy.Right;
                }

                if (root.Right != null)
                {
                    if (dummy.Right == null)
                    {
                        falseLinks.Add(dummy);
                    }

                    dummy.Right = root.Right;
                    dummy = dummy.Right;
                }

                root = root.Right;
            }

            yield return sum;
            root = dummy.Right;
        }

        foreach (var node in falseLinks)
        {
            node.Right = null;
        }
    }
}

class Program
{
    static void Main()
    {
        var root = new Node {
            Val = 1,
            Left = new Node {
                Val = 2,
                Left = new Node {
                    Val = 9,
                    Right = new Node {
                        Val = 10
                    }
                },
                Right = new Node {
                    Val = 6,
                    Left = new Node {
                        Val = 11
                    }
                }
            },
            Right = new Node {
                Val = 3,
                Left = new Node {
                    Val = 4,
                    Left = new Node {
                        Val = 12
                    },
                    Right = new Node {
                        Val = 7
                    }
                },
                Right = new Node {
                    Val = 5
                }
            }
        };

        Console.WriteLine(root);
        Console.WriteLine(String.Join(", ", Node.GetSums(root)));
        Console.WriteLine(root);
    }
}
