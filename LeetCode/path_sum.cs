using System;
using System.Collections.Generic;

class Node {
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
}

class Program {

    static bool Sum(Node current, int target, int sum, int[] prev) {
        if (current.Left == null && current.Right == null) {
            if (target == sum + current.Value) {
                int node = current.Value;
                while (0 < node && node < prev.Length) {
                    Console.Write("{0} ", node);
                    node = prev[node];
                }

                Console.WriteLine();
                return true;
            } else {
                return false;
            }
        }
        
        bool left = false;
        bool right = false;
        if (current.Left != null) {
            prev[current.Left.Value] = current.Value;
            left = Sum(current.Left, target, sum + current.Value, prev);
        }

        if (current.Right!= null) {
            prev[current.Right.Value] = current.Value;
            right = Sum(current.Right, target, sum + current.Value, prev);
        }

        return left || right;
    }

    static void Main() {
        Node root = new Node {
                                Value = 5,
                                Left = new Node {
                                                    Value = 4,
                                                    Left = new Node {
                                                                        Value = 11,
                                                                        Left = new Node {
                                                                                            Value = 7,
                                                                                            Left = null,
                                                                                            Right = null
                                                                                        },
                                                                        Right = new Node {
                                                                                            Value = 2,
                                                                                            Left = null,
                                                                                            Right = null
                                                                                         }
                                                                    },
                                                    Right = null
                                                },
                                Right = new Node {
                                                    Value = 8,
                                                    Left = new Node {
                                                                        Value = 13,
                                                                        Left = null,
                                                                        Right = null
                                                                    },
                                                    Right = new Node {
                                                                        Value = 6,
                                                                        Left = null,
                                                                        Right = new Node {
                                                                                            Value = 1,
                                                                                            Left = null,
                                                                                            Right = null
                                                                                         }
                                                                     }
                                                 }
                             };

        Console.WriteLine(Sum(root, 22, 0, new int[100]));
    }
}
