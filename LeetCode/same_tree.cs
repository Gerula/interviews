using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Node {
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    public int HashCode { get; private set; }

    public void Rehash() {
        HashCode = Value.GetHashCode();
        if (Left != null) {
            HashCode += Left.HashCode;
        }

        if (Right != null) {
            HashCode += Right.HashCode;
        }
    }
    
    public bool Equals(Node other) {
        if (other == null) {
            return false;
        }

        return this.HashCode == other.HashCode;
    }
}

class Tree {
    private Node Root { get; set; }

    public void Add(int value) {
        Root = Add(Root, new Node { Value = value });
    }

    private Node Add(Node parent, Node newNode) {
        if (parent == null) {
            newNode.Rehash();
            return newNode;
        }

        if (parent.Value > newNode.Value) {
            parent.Left = Add(parent.Left, newNode);
        } else {
            parent.Right = Add(parent.Right, newNode);
        }

        parent.Rehash();
        return parent;
    }

    public bool Equals(Tree other) {
        return this.Root.Equals(other.Root);
    }

    public override String ToString() {
        StringBuilder result = new StringBuilder();
        Stack<Node> stack = new Stack<Node>();
        Node current = Root;
        while (stack.Any() || current != null) {
            if (current == null) {
                current = stack.Pop();
                result.Append(String.Format("{0}-{1} ", current.Value, current.HashCode));
                current = current.Right;
            } else {
                stack.Push(current);
                current = current.Left;
            }
        }

        return result.ToString();
    }

    public static bool Equals(Tree first, Tree second) {
        return Equals(first.Root, second.Root);
    }

    private static bool Equals(Node first, Node second) {
        if (first == null || second == null) {
            return first == null && second == null;
        }

        return (first.Value == second.Value) && Equals(first.Left, second.Left) && Equals(first.Right, second.Right);
    }
}

class Program {
    static void Main() {
        Tree tree = new Tree();
        Enumerable.Range(1, 6).ToList().ForEach(x => tree.Add(x));
        Console.WriteLine(tree);
        Tree other = new Tree();
        Enumerable.Range(1, 5).ToList().ForEach(x => other.Add(x));
        Console.WriteLine(other);
        Console.WriteLine("Equals? {0}", tree.Equals(other));
        Console.WriteLine("Equals rec? {0}", Tree.Equals(tree, other));
        other.Add(6);
        Console.WriteLine("Equals? {0}", tree.Equals(other));
        Console.WriteLine("Equals rec? {0}", Tree.Equals(tree, other));
    }
}
