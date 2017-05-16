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

    //  https://leetcode.com/submissions/detail/62752162/
    //  
    //  Submission Details
    //  21 / 21 test cases passed.
    //      Status: Accepted
    //      Runtime: 216 ms
    //          
    //          Submitted: 7 minutes ago
    public ListNode InsertionSortList(ListNode head) {
        var preStart = new ListNode(-1);
        
        var it = head;
        while (it != null) {
            var next = it.next;
            var insert = preStart;
            while (insert.next != null && insert.next.val < it.val)
            {
                insert = insert.next;
            }
            
            it.next = insert.next;
            insert.next = it;
            it = next;
        }
        
        return preStart.next;
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
