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
        Node less = null, lastLess = null;
        Node equal = null, lastEqual = null;
        Node more = null, lastMore = null;
        
        Node iterator = this;
        while (iterator != null) {
            Node next = iterator.Link;
            if (iterator.Value == value) {
                AdvanceIterator(ref equal, ref lastEqual, ref iterator, next);
            } else if (iterator.Value < value) {
                AdvanceIterator(ref less, ref lastLess, ref iterator, next);
            } else {
                AdvanceIterator(ref more, ref lastMore, ref iterator, next);
            }
        }

        less.Link = lastEqual;
        equal.Link = lastMore;
        return lastLess;
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
