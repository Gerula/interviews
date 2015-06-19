using System;

class Node {
    public Node(int val, Node left, Node right) {
        Value = val; Left = left; Right = right;
    }

    public int Value { get; private set; }
    public Node Left { get; private set; }
    public Node Right { get; private set; }
}

class Program{
    static bool IsMirror(Node left, Node right) {
        if (left == null || right == null) {
            return left == null && right == null;
        }

        return ((left.Value == right.Value) && IsMirror(left.Right, right.Left) && IsMirror(left.Left, right.Right));
    }

    static void Main() {
        Node root = new Node(1,
                             new Node(2,
                                      new Node(3, null, null),
                                      new Node(4, null, null)),
                             new Node(2,
                                      new Node(4, null, null),
                                      new Node(3, null, null)));
       Node unroot = new Node(1,
                              new Node(2,
                                       null,
                                       new Node(4, null, null)),
                              new Node(2,
                                       null,
                                       new Node(4, null, null)));

       Console.WriteLine("First {0}", IsMirror(root.Left, root.Right));
       Console.WriteLine("Second {0}", IsMirror(unroot.Left, unroot.Right));
    }
}
