//  https://leetcode.com/problems/reorder-list/
//
//   Given a singly linked list L: L0→L1→…→Ln-1→Ln,
//   reorder it to: L0→Ln→L1→Ln-1→L2→Ln-2→…
//
//   You must do this in-place without altering the nodes' values.
//
//   For example,
//   Given {1,2,3,4}, reorder it to {1,4,2,3}. 

using System;

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }

    public override String ToString()
    {
        return String.Format("{0} {1}", val, next == null ? String.Empty : next.ToString());
    }
}

public class Solution {
    //  
    //  Submission Details
    //  13 / 13 test cases passed.
    //      Status: Accepted
    //      Runtime: 188 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //          https://leetcode.com/submissions/detail/49593972/
    //
    public void ReorderList(ListNode head) {
        if (head == null || head.next == null)
        {
            return;
        }

        var slow = head;
        var fast = head.next;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        var head2 = slow.next;
        slow.next = null;

        ListNode prev = null;
        ListNode reverse = head2;
        while (reverse != null)
        {
            var next = reverse.next;
            reverse.next = prev;
            prev = reverse;
            reverse = next;
        }

        head2 = prev;
        
        while (head != null)
        {
            var firstNext = head.next;
            head.next = head2;
            head = head.next;
            head2 = firstNext;
        }
    }

    static void Main()
    {
        ListNode root = null;
        for (var i = 4; i >= 1; i--)
        {
            root = new ListNode(i) { next = root };
        }

        Console.WriteLine(root);
        new Solution().ReorderList(root);
        Console.WriteLine(root);

        root = null;
        for (var i = 3; i >= 1; i--)
        {
            root = new ListNode(i) { next = root };
        }

        Console.WriteLine(root);
        new Solution().ReorderList(root);
        Console.WriteLine(root);
    }
}
