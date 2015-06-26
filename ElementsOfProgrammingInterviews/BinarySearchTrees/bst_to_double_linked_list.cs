using System;
using System.Collections.Generic;
using System.Linq;

class Node {
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
}

class Program {
    static IEnumerable<Node> Inorder(Node root) {
        Stack<Node> stack = new Stack<Node>();
        while ((root != null) || (stack.Any())) {
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

    static Node Fill(int left, int right) {
        if (left > right) {
            return null;
        }
        
        int mid = left + (right - left) / 2;
        return new Node {
            Value = mid,
            Left = Fill(left, mid - 1),
            Right = Fill(mid + 1, right)
        };
    }

    static Node ToSingleList(Node root) {
        if (root == null) {
            return null;
        }

        Node left = root.Left;
        Node right = root.Right;
        root.Left = null;
        root.Right = null;

        left = ToSingleList(left);
        right = ToSingleList(right);

        Node last = root;
        if (left != null) {
            root.Right = left;
            while (last.Right != null) {
                last = last.Right;
            }
        }
        
        last.Right = right;

        return root;
    }

    static Node ToDoubleLinked(Node root) {
        if (root == null) {
            return null;
        }

        if (root.Left != null) {
            Node left = ToDoubleLinked(root.Left);
            while (left.Right != null) {
                left = left.Right;
            }

            left.Right = root;
            root.Left = left;
        }

        if (root.Right != null) {
            Node right = ToDoubleLinked(root.Right);
            while (right.Left != null) {
                right = right.Left;
            }

            right.Left = root;
            root.Right = right;
        }

        return root;
    }

    static Node ToDoubleLinkedBetter(Node root) {
        Node prev = null;
        LeftSide(root, ref prev);

        Node right = null;
        while (prev != null) {
            Node left = prev.Left;
            prev.Right = right;
            right = prev;
            prev = left;
        }

        return right;
    }

    static void LeftSide(Node root, ref Node previous) {
        if (root == null) {
            return;
        }

        LeftSide(root.Left, ref previous);
        root.Left = previous;
        previous = root;
        LeftSide(root.Right, ref previous);
    }

    static void Main() {
        Node root = Fill(1, 10);
        Console.WriteLine(String.Join(",", Inorder(root).Select(x => x.Value)));
        root = ToDoubleLinkedBetter(root);

        Node it = root;
        while (it != null) {
            Console.Write("{0} ", it.Value);
            it = it.Right;
        }

        Console.WriteLine();
    }
}
