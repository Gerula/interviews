//  https://leetcode.com/problems/remove-nth-node-from-end-of-list/
//
//  Given a linked list, remove the nth node from the end of list and return its head.
//
//  For example,
//
//     Given linked list: 1->2->3->4->5, and n = 2.
//
//     After removing the second node from the end, the linked list becomes 1->2->3->5.
//

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */

//  https://leetcode.com/submissions/detail/52810229/
//
//
//  Submission Details
//  207 / 207 test cases passed.
//      Status: Accepted
//      Runtime: 168 ms
//          
//          Submitted: 0 minutes ago
//
//  You are here!
//  Your runtime beats 29.52% of csharp submissions.
public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        var i = 1;
        return RemoveNthFromEnd(head, n, ref i);
    }

    public ListNode RemoveNthFromEnd(ListNode head, int n, ref int i) {
        if (head == null)
        {
            return head;
        }
        
        head.next = RemoveNthFromEnd(head.next, n, ref i);
        var result = i == n ? head.next : head;
        i++;
        return result;
    }
}

//  https://leetcode.com/submissions/detail/52810580/
//
//
//  Submission Details
//  207 / 207 test cases passed.
//      Status: Accepted
//      Runtime: 172 ms
//          
//          Submitted: 0 minutes ago
//
//
//  You are here!
//  Your runtime beats 19.05% of csharp submissions. LOL
public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        var dummy = new ListNode(0) { next = head };
        var pre = dummy;
        var i = 1;
        while (i != n)
        {
            i++;
            head = head.next;
        }
        
        while (head.next != null)
        {
            head = head.next;
            pre = pre.next;
        }
        
        pre.next = pre.next.next;
        return dummy.next;
    }
}
