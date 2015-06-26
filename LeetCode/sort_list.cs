using System;
using System.Linq;
using System.Text;

class Node {
    public Node(int value, Node link) {
        Value = value;
        Link = link;
    }

    public int Value { get; } 
    public Node Link { get; set; }

    public override String ToString() {
        StringBuilder result = new StringBuilder();
        Node it = this;
        while (it != null) {
            result.Append(String.Format("{0} ", it.Value));
            it = it.Link;
        }

        return result.ToString();
    }

    public static Node Generate(int start, int count) {
        Node node = null;
        Enumerable.Range(1, 10).ToList().ForEach(x => node = new Node(x, node));
        return node; 
    }

    public static Node BubbleSort(Node start) {
        Node root = start;
        bool sorted;
        do {
            sorted = true;
            Node prev = null;
            Node current = root;
            while (current != null && current.Link != null && current.Value > current.Link.Value) {
                sorted = false;
                Node next = current.Link;
                if (prev == null) {
                    root = next;
                } else {
                    prev.Link = next;
                }

                current.Link = next.Link;
                next.Link = current;
                prev = next;
            }

        } while (!sorted);

        return root;
    }
}

class Program {
    static void Main() {
        Node list = Node.Generate(1, 10);
        Console.WriteLine(Node.BubbleSort(list));
    }
}
