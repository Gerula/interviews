// http://www.careercup.com/question?id=4796489274490880
//
// I should paste the problem here but CareerCup website sucks

using System;
using System.Linq;

class ListNode {
    public int Value { get; set; }
    public ListNode Next { get; set; }
    public override String ToString() {
        return String.Format("{0} {1}", Value, Next == null ? String.Empty : Next.ToString());
    }

    public ListNode Split(int offset) {
        ListNode start = null;
        ListNode end = null;
        ListNode iterator = this;
        
        while (offset > 1) {
            start = iterator;
            iterator = iterator.Next;
            offset--;
        }

        end = this;
        while (iterator.Next != null) {
            iterator = iterator.Next;
            end = end.Next;
        }

        ListNode link = end.Next;
        end.Next = null;
        start.Next = start.Next.Reverse();
        iterator = start.Next;
        while (iterator.Next != null) {
            iterator = iterator.Next;
        }

        iterator.Next = link;
        
        return this;
    }

    private ListNode Reverse() {
        ListNode prev = null;
        ListNode current = this;
        while (current != null) {
            ListNode next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }

        return prev;
    }
}

class Program {
    static void Main() {
        ListNode head = null;
        Enumerable.Range(1, 5).Reverse().ToList().ForEach(x => {
                    head = new ListNode {
                        Value = x,
                        Next = head
                    };
                });

        Console.WriteLine(head);
        Console.WriteLine(head.Split(2));
    }
}
