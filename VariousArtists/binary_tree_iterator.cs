using System;
using System.Collections.Generic;

class Node {
    public int Data { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public static Node Fill(int low, int high) {
        int mid = low + (high - low) / 2;
        return (low > high) ? null : new Node { Data = mid,
                                                Left = Fill(low, mid - 1),
                                                Right = Fill(mid + 1, high)};
    }

    public void Inorder() {
        if (this.Left != null) {
            this.Left.Inorder();
        }

        Console.Write("{0} ", this.Data);

        if (this.Right != null) {
            this.Right.Inorder();
        }
    }
}

class Tree : IEnumerable<Node> {
    public Node Root { get; set; }
    public IEnumerator<Node> Enumerator { get; set; }

    public IEnumerator<Node> GetEnumerator() {
        return Enumerator;
    }

   System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
   {
       return Enumerator;
   }

   public IEnumerable<Node> Inorder(Node node) {
        if (node.Left != null) {
            foreach (Node left in Inorder(node.Left)) {
                yield return left;
            }
        }
        
        yield return node;

        if (node.Right != null) {
            foreach (Node right in Inorder(node.Right)) {
                yield return right;
            }
        }
   }
}

class NodeEnumerator : IEnumerator<Node> {
    private Stack<Node> stack = new Stack<Node>();
    private Node current;
    private Node inorderCurrent;
    private Node start;

    public NodeEnumerator(Node node) {
        current = node;
        inorderCurrent = node;
        start = node;
    }

    public Node Current {
        get {
            return current; 
        }
    }

    object System.Collections.IEnumerator.Current
    {
        get {
            return current; 
        }
    }

    public bool MoveNext() {
        while (stack.Count != 0 || inorderCurrent != null) {
            if (inorderCurrent == null) {
                inorderCurrent = stack.Pop();
                current = inorderCurrent;
                inorderCurrent = inorderCurrent.Right;
                return true;            
            } else {
                stack.Push(inorderCurrent);
                inorderCurrent = inorderCurrent.Left;
            }
        }

        return false;
    }

    public void Reset() {
        stack.Clear();
        current = start;
    }

    public void Dispose() {
    }
}

class Program {
    static void Main() {
        Node node = Node.Fill(1, 10);
        node.Inorder();
        Console.WriteLine();
        Tree tree = new Tree() { Root = node, Enumerator = new NodeEnumerator(node) };

        foreach (Node it in tree) {
            Console.Write("Enum {0}", it.Data);
        } 
        
        Console.WriteLine();

        foreach (Node it in tree.Inorder(tree.Root)) {
            Console.Write("In {0}", it.Data);
        } 
        
        Console.WriteLine();
    }
}
