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
    //  
    //  Submission Details
    //  15 / 15 test cases passed.
    //      Status: Accepted
    //      Runtime: 196 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  https://leetcode.com/submissions/detail/51758343/
    //
    //  Accepted as the merge operation doesn't blow up the stack.
    //
    public ListNode SortListOld(ListNode head) {
        if (head == null || head.next == null)
        {
            return head;
        }

        var fast = head.next;
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

    //  
    //  Submission Details
    //  15 / 15 test cases passed.
    //      Status: Accepted
    //      Runtime: 168 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  https://leetcode.com/submissions/detail/51766108/
    //
    //  Whoah!!
    //  You are here!
    //  Your runtime beats 91.30% of csharp submissions.
    //  
    //  Ok, Quicksort kicks ass.
    public ListNode SortList(ListNode head) {
        if (head == null || head.next == null)
        {
            return head;
        }

        var smallerStart = new ListNode(0);
        var equalStart = new ListNode(0);
        var largerStart = new ListNode(0);
        var smaller = smallerStart;
        var equal = equalStart;
        var larger = largerStart;

        var it = head;
        while (it != null)
        {
            if (it.val == head.val)
            {
                equal.next = it;
                equal = equal.next;
            } 
            else if (it.val < head.val)
            {
                smaller.next = it;
                smaller = smaller.next;
            }
            else
            {
                larger.next = it;
                larger = larger.next;
            }

            it = it.next;
        }

        smaller.next = equal.next = larger.next = null;
        smallerStart.next = SortList(smallerStart.next);
        largerStart.next = SortList(largerStart.next);
        
        it = smallerStart;
        while (it.next != null)
        {
            it = it.next;
        }

        it.next = equalStart.next;
        while (it.next != null)
        {
            it = it.next;
        }

        it.next = largerStart.next;
        return smallerStart.next;
    }

    public ListNode Merge(ListNode a, ListNode b)
    {
        var dummy = new ListNode(0);
        var it = dummy;
        while (a != null && b != null)
        {
            if (a.val < b.val)
            {
                it.next = a;
                it = a;
                a = a.next;
            }
            else
            {
                it.next = b;
                it = b;
                b = b.next;
            }
        }

        if (a == null)
        {
            it.next = b;
        }

        if (b == null)
        {
            it.next = a;
        }

        return dummy.next;
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
