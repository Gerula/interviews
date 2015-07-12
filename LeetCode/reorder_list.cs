using System;
using System.Collections.Generic;
using System.Linq;

class Node {
    public int Data { get; set; }
    public Node Next { get; set; }

    public override String ToString() {
        return String.Format("{0} {1}", Data, (Next == null) ? String.Empty : Next.ToString());
    }
}

class Program {
    static void Main() {
        Node head = null;
        Enumerable.Range(1, 20).Reverse().ToList().ForEach(x => {
                        head = new Node {
                               Data = x,
                               Next = head
                        };
                   } );        

        Node mid = null;
        Node end = head;
        while (end != null && end.Next != null) {
            mid = (mid == null)? head : mid.Next;
            end = end.Next.Next;
        }

        Node head2 = mid.Next;
        mid.Next = null;
        Node first = head;
        Node second = head2;
        while (first != null && second != null) {
            Node firstNext = first.Next;
            Node secondNext = second.Next;
            first.Next = second;
            second.Next = firstNext;
            second = secondNext;
            first = firstNext;
        }

        Console.WriteLine(head);
    }
}
