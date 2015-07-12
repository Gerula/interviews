using System;
    
class Node {
    public int Value { get; set; }
    public Node Next { get; set; }

    public Node(int value, Node next) {
        Value = value; Next = next;
    }

    public override String ToString() {
        return String.Format("{0} {1}",
                             Value,
                             (Next != null) ?
                             Next.ToString() : String.Empty);
    }
}

static class Program {
    static Node StripDupes(this Node head) {
        Node it = head;
        while (it != null) {
            while (it.Next != null && it.Next.Value == it.Value) {
                it.Next = it.Next.Next;
            }

            it = it.Next;
        }

        return head;
    }

    static void Main() {
        Node head = null;
        head = new Node(3, head);
        head = new Node(3, head);
        head = new Node(3, head);
        head = new Node(2, head);
        head = new Node(2, head);
        head = new Node(1, head);
        head = new Node(1, head);
        head = new Node(1, head);
        Console.WriteLine(head);
        head = head.StripDupes();
        Console.WriteLine(head);
    }
}
