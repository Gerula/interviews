using System;
using System.Collections.Generic;
using System.Linq;

class Node {
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
}

class Program {
    static Node Fill(int low, int high) {
        if (low > high) {
            return null;
        }
        
        int mid = low + (high - low) / 2;
        return new Node { Value = mid,
                          Left = Fill(low, mid - 1),
                          Right = Fill(mid + 1, high) };
    }

    static IEnumerable<Node> Inorder(Node root) {
        Stack<Node> stack = new Stack<Node>();
        while (stack.Any() || root != null) {
            if (root == null) {
                root = stack.Pop();
                yield return root;
                root = root.Right;
            } else {
                stack.Push(root);
                root = root.Left;
            }
        }
    }

    static bool IsBst(Node root, int low, int high) {
        return root == null || (low <= root.Value && root.Value <= high && 
                                IsBst(root.Left, low, root.Value) && 
                                IsBst(root.Right, root.Value, high));
    }

    static void Main() {
        Node root = Fill(1, 10);
        Console.WriteLine(String.Join(",", Inorder(root).Select(x => x.Value)));        
        Console.WriteLine(IsBst(root, int.MinValue, int.MaxValue));
        root.Value = 0;
        Console.WriteLine(IsBst(root, int.MinValue, int.MaxValue));
    }
}
