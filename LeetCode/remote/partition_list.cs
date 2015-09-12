using System;

class Node {
    public int Value { get; set; }
    public Node Link { get; set; }

    public override String ToString() {
        return String.Format("{0}{1}", Value, Link == null? String.Empty : String.Format(" -> {0}", Link));
    }

    private static void AdvanceIterator(ref Node first, ref Node last, ref Node iterator, Node next) {
        first = first ?? iterator;
        iterator.Link = last;
        last = iterator;
        iterator = next;
    }

    public Node Partition(int value) {
        Node leftReference = new Node { Value = -1 };
        Node rightReference = new Node { Value = -1 };
        Node left = leftReference;
        Node right = rightReference;

        Node iterator = this;
        while (iterator != null) {
            if (iterator.Value < value) {
                left.Link = iterator;
                left = iterator;
            } else {
                right.Link = iterator;
                right = iterator;
            }

            iterator = iterator.Link;
        }

        right.Link = null;
        left.Link = rightReference.Link;
        return leftReference.Link;
    }
}

class Program {
    static void Main() {
        Node head = null;
        head = new Node { Value = 2, Link = head };
        head = new Node { Value = 5, Link = head };
        head = new Node { Value = 2, Link = head };
        head = new Node { Value = 3, Link = head };
        head = new Node { Value = 4, Link = head };
        head = new Node { Value = 1, Link = head };
        Console.WriteLine(head.ToString());
        Console.WriteLine(head.Partition(3).ToString());
    }
}
