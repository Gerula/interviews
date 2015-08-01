using System;

class Node {
    public int value;
    public Node left;
    public Node right;
}

class Program {
    static bool IsBalanced(Node node) {
        return GetBalancedHeight(node) != -1;
    }

    static int GetBalancedHeight(Node node) {
        if (node == null) {
            return 0;
        }

        int leftHeight = GetBalancedHeight(node.left);
        int rightHeight = GetBalancedHeight(node.right);

        if (leftHeight == -1 || rightHeight == -1) {
            return -1;
        }

        if (Math.Abs(leftHeight - rightHeight) > 1) {
            return -1;
        }

        return 1 + Math.Max(leftHeight, rightHeight);
    }

    static void Main() {
        Console.WriteLine("{0}, {1}", IsBalanced(null), true);
        Node root = new Node {
                        value = 1,
                        left = new Node {
                               value = 2
                        },
                        right = new Node {
                                value = 3
                        }};
        Console.WriteLine("{0}, {1}", IsBalanced(root), true);
        root.left.left = new Node {
                         value = 4,
                         left = new Node {
                                value = 5
                         }};
        Console.WriteLine("{0}, {1}", IsBalanced(root), false);
    }
}

