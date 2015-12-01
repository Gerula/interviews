// http://www.geeksforgeeks.org/merge-two-sorted-linked-lists-such-that-merged-list-is-in-reverse-order/
//
// Given two linked lists sorted in increasing order.
// Merge them such a way that the result list is in decreasing order (reverse order).

using System;
using System.Linq;

class Node
{
    public int Val { get; set; }
    public Node Next { get; set; }
    public override String ToString()
    {
        return String.Format("{0} {1}", Val, Next == null ? String.Empty : Next.ToString());
    }
}

class Program
{
    static void Main()
    {
        Node head1 = null;
        Node head2 = null;
        new [] { 40, 15, 10, 5 }.ToList().ForEach(x => { head1 = new Node { Val = x, Next = head1}; });
        new [] { 20, 3, 2 }.ToList().ForEach(x => { head2 = new Node { Val = x, Next = head2}; });
        Console.WriteLine(head1);
        Console.WriteLine(head2);
        Node head3 = null;
        var it1 = head1;
        var it2 = head2;
        while (it1 != null || it2 != null)
        {
            var val1 = it1 == null ? int.MaxValue : it1.Val;
            var val2 = it2 == null ? int.MaxValue : it2.Val;
            Node next = null;
            if (val1 < val2)
            {
                next = it1.Next;
                it1.Next = head3;
                head3 = it1;
                it1 = next;
            }
            else
            {
                next = it2.Next;
                it2.Next = head3;
                head3 = it2;
                it2 = next;
            }
        }

        Console.WriteLine(head3);
    }
}
