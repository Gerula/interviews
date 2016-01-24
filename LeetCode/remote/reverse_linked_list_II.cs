//  https://leetcode.com/problems/reverse-linked-list-ii/
//
//   Reverse a linked list from position m to n. Do it in-place and in one-pass.
//
//   For example:
//   Given 1->2->3->4->5->NULL, m = 2 and n = 4,
//
//   return 1->4->3->2->5->NULL.
//
//   Note:
//   Given m, n satisfy the following condition:
//   1 ≤ m ≤ n ≤ length of list. 

using System;

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }

    public override String ToString()
    {
        return String.Format(
                "{0}{1}",
                val,
                next == null ? String.Empty : String.Format("->{0}", next.ToString()));
    }
}

public class Solution {
    //  
    //  Submission Details
    //  44 / 44 test cases passed.
    //      Status: Accepted
    //      Runtime: 148 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  https://leetcode.com/submissions/detail/51654975/
    //
    //  You are here!
    //  Your runtime beats 87.04% of csharp submissions.
    public ListNode ReverseBetween(ListNode head, int m, int n) {
        if (head == null || head.next == null)
        {
            return head;
        }

        var dummy = new ListNode(-1) { next = head };
        var pre = dummy;
        for (var i = 0; i < m - 1; i++)
        {
            pre = pre.next;
        }

        var start = pre.next;
        var it = start.next;

        for (var i = 0; i < n - m; i++)
        {
            start.next = it.next;
            it.next = pre.next;
            pre.next = it;
            it = start.next;
        }

        return dummy.next;
    }

    static void Main()
    {
        var s = new Solution();
        ListNode head = null;
        for (var i = 5; i > 0; i--)
        {
            head = new ListNode(i) { next = head };
        }

        Console.WriteLine(head);
        head = s.ReverseBetween(head, 2, 4);
        Console.WriteLine(head);
    }
}
