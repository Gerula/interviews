using System;

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
    public override String ToString() {
        return String.Format(" {0}{1}", val, next == null? String.Empty : next.ToString());
    }
}

class Program {
    public static ListNode InsertionSortList(ListNode head) {
        ListNode moq = new ListNode(-1);

        while (head != null) {
            ListNode next = head.next;
            ListNode start = moq;
            while (start.next != null && start.next.val < head.val) {
                start = start.next;
            }

            head.next = start.next;
            start.next = head;
            head = next;
        }

        return moq.next;
    }

    static void Main() {
        Random rand = new Random();
        for (int k = 0; k < 10; k++) {
            ListNode head = null;
            Console.WriteLine("==============");
            int size = rand.Next(0, 20);
            for (int i = 0 ; i < size; i++) {
                head = new ListNode(rand.Next(1, 200)) { next = head };
            }

            Console.WriteLine(head);
            Console.WriteLine(InsertionSortList(head));
        }
    }
}
