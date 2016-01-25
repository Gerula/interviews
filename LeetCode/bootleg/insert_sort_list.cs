//  https://leetcode.com/problems/insertion-sort-list/
//
//  Sort a linked list using insertion sort.

using System;
using System.Text;

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }

    public override String ToString()
    {
        var result = new StringBuilder();
        for (var it = this; it != null; it = it.next)
        {
            result.Append(String.Format("{0} ", it.val));
        }

        return result.ToString();
    }
}

public class Solution {
    //  
    //  Submission Details
    //  21 / 21 test cases passed.
    //      Status: Accepted
    //      Runtime: 208 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  https://leetcode.com/submissions/detail/51734393/
    //
    public ListNode InsertionSortList(ListNode head) {
        if (head == null)
        {
            return head;
        }

        var dummy = new ListNode(-1);
        var it = head;
        while (it != null)
        {
            var next = it.next;
            var insert = dummy;
            while (insert.next != null && insert.next.val < it.val)
            {
                insert = insert.next;
            }

            it.next = insert.next;
            insert.next = it;
            it = next;
        }

        return dummy.next;
    }

    static void Main()
    {
        ListNode head = null;
        var r = new Random();
        var n = r.Next(30);
        for (var i = 0; i < n; i++)
        {
            head = new ListNode(r.Next(20)) { next = head };
        }

        Console.WriteLine(head);
        Console.WriteLine(new Solution().InsertionSortList(head));
    }
}
