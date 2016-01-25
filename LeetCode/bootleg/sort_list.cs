//  https://leetcode.com/problems/sort-list/
//
//  Sort a linked list in O(n log n) time using constant space complexity.

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
                next == null ?
                    String.Empty :
                    String.Format(" -> {0}", next.ToString()));
    }
}

public class Solution {
    public ListNode SortList(ListNode head) {
        if (head == null || head.next == null)
        {
            return head;
        }

        var fast = head.next.next;
        var slow = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        var right = SortList(slow.next);
        slow.next = null;
        var left = SortList(head);
        
        return Merge(left, right);
    }

    public ListNode Merge(ListNode a, ListNode b)
    {
        if (a == null)
        {
            return b;
        }

        if (b == null)
        {
            return a;
        }

        if (a.val < b.val)
        {
            a.next = Merge(a.next, b);
            return a;
        }

        b.next = Merge(a, b.next);
        return b;
    }

    static void Main()
    {
        var r = new Random();
        var count = r.Next(30);
        ListNode head = null;
        for (var i = 0; i < count; i++)
        {
            head = new ListNode(r.Next(30)) { next = head };
        }

        Console.WriteLine(head);
        Console.WriteLine();
        Console.WriteLine(new Solution().SortList(head));
    }
}
