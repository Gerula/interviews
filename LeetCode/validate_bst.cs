//  Given a binary tree, determine if it is a valid binary search tree (BST). 
using System;
using System.IO;
using System.Text;

class Node {
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(int value, Node left, Node right) {
        Value = value; Left = left; Right = right;
    }
}

class Tree {
    private Node _root;

    public Tree(int left, int right) {
        _root = Build(left, right);
    }

    private Node Build(int left, int right) {
        if (left > right) {
            return null;
        }
        
        int mid = left + (right - left) / 2;
        return new Node(mid, Build(left, mid - 1), Build(mid + 1, right));
    }

    public override string ToString() {
        StringBuilder result = new StringBuilder();
        Inorder(_root, result);
        result.Append(String.Format(" IsBst? {0}", IsBst()));
        result.Append(String.Format(" IsBalanced? {0}", IsBalanced()));
        return result.ToString();
    }

    private void Inorder(Node current, StringBuilder result) {
        if (current != null) {
            Inorder(current.Left, result);
            result.Append(String.Format("{0} ", current.Value));
            Inorder(current.Right, result);
        }
    }

    public void ScrewWithIt() {
        _root.Left.Right.Value = int.MaxValue;
        Node it = _root;
        while (it.Left != null) {
            it = it.Left;
        }

        it.Left = new Node(10,
                           new Node(11,
                                    new Node(12,
                                             new Node(13, null, null),
                                             null),
                                    null),
                           null);
    }

    public bool IsBst() {
        return IsBst(_root, int.MinValue, int.MaxValue);
    }

    private bool IsBst(Node current, int min, int max) {
        if (current == null) {
            return true;
        }

        return (min <= current.Value && current.Value <= max) &&
                IsBst(current.Left, min, current.Value) &&
                IsBst(current.Right, current.Value, max);
    }

    public bool IsBalanced() {
        return IsBalanced(_root) != -1;
    }

    private int IsBalanced(Node current) {
        if (current == null) {
            return 0;
        }

        int left = IsBalanced(current.Left);
        int right = IsBalanced(current.Right);
        if ((Math.Abs(left - right) > 1) || (left == -1) || (right == -1)) {
            return -1;
        } else {
            return Math.Max(left, right) + 1;
        }
    }
}

class Program {
    public static void Main(string[] args) {
        Tree tree = new Tree(0, 10);
        Console.WriteLine(tree);
        tree.ScrewWithIt();
        Console.WriteLine(tree);
    }
}

