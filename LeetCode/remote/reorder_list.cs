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
    public void ReorderList(ListNode head) {
        if (head == null)
        {
            return;
        }

        var slow = head;
        var mid = new ListNode(0);
        mid.next = slow;
        var fast = head;
        while (fast != null && fast.next != null)
        {
            mid.next = slow;
            slow = slow.next;
            fast = fast.next.next;
        }

        mid.next.next = null;
        mid = slow;
        ListNode prev = null;
        while (slow != null)
        {
            var next = slow.next;
            slow.next = prev;
            prev = slow;
            slow = next;
        }
        
        mid = prev;
        while (mid != null)
        {
            var firstNext = head.next;
            var secondNext = mid.next;
            head.next = mid;
            mid.next = firstNext;
            head = firstNext;
            mid = secondNext;
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
