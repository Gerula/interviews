//  http://www.geeksforgeeks.org/diagonal-sum-binary-tree/

using System;
using System.Collections.Generic;
using System.Linq;

class Node
{
    public int Val { get; set; }
    public int Diag { get; set; }
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
        var queue = new Queue<Node>();
        var sums = new Dictionary<int, int>();
        while (root != null)
        {
            root.Diag = 0;
            queue.Enqueue(root);
            root = root.Right;
        }

        while (queue.Any())
        {
            root = queue.Dequeue();
            if (!sums.ContainsKey(root.Diag))
            {
                sums[root.Diag] = 0;
            }
            
            sums[root.Diag] += root.Val;
            if (root.Left != null)
            {
                var it = root.Left;
                while (it != null)
                {
                    it.Diag = root.Diag + 1;
                    queue.Enqueue(it);
                    it = it.Right;
                }
            }
        }

        return sums.Values;
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
