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
        return String.Format("{0} {1}", val, next == null ? String.Empty : next.ToString());
    }
}

public class Solution {
    public ListNode SortList(ListNode head) {
        if (head == null || head.next == null)
        {
            return head;
        }

        var slow = head;
        var fast = head.next.next;
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
        if (a == null || b == null)
        {
            return b == null ? a : b;
        }
    
        if (a.val < b.val)
        {
            a.next = Merge(a.next, b);
            return a;
        }
        else
        {
            b.next = Merge(a, b.next);
            return b;
        }
    }

    static void Main()
    {
        var s = new Solution();
        ListNode head = null;
        var rand = new Random();
        for (var i = 0; i < 20; i++)
        {
            head = new ListNode(rand.Next(20)) { next = head };
        }

        Console.WriteLine(head);
        Console.WriteLine(s.SortList(head));
    }
}

//  https://leetcode.com/submissions/detail/61085899/
//
//  Submission Details
//  15 / 15 test cases passed.
//      Status: Accepted
//      Runtime: 204 ms
//          
//          Submitted: 0 minutes ago
//
public class Solution {
    public ListNode SortList(ListNode head) {
        if (head == null || head.next == null)
        {
            return head;
        }
        
        var slow = head;
        var fast = slow.next;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        
        var upper = slow.next;
        slow.next = null;
        return Merge(SortList(head), SortList(upper));
    }
    
    public ListNode Merge(ListNode a, ListNode b)
    {
        var resultHead = new ListNode(-1);
        var result = resultHead;
        while (a != null || b != null)
        {
            if (a != null && (b == null || a.val < b.val))
            {
                result.next = a;
                a = a.next;
            }
            else
            {
                result.next = b;
                b = b.next;
            }
            
            result = result.next;
        }
        
        return resultHead.next;
    }
}
