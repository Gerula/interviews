//  https://leetcode.com/problems/rotate-list/
//  
//  Given a list, rotate the list to the right by k places, where k is non-negative.
//
//  For example:
//  Given 1->2->3->4->5->NULL and k = 2,
//  return 4->5->1->2->3->NULL.

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    //  https://leetcode.com/submissions/detail/51636506/
    //
    //
    //  Submission Details
    //  230 / 230 test cases passed.
    //      Status: Accepted
    //      Runtime: 184 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public ListNode RotateRight(ListNode head, int k) {
        if (head == null || head.next == null || k == 0)
        {
            return head;
        }
        
        var length = 1;
        var it = head;
        while (it.next != null)
        {
            it = it.next;
            length++;
        }
        
        var prev = it;
        it.next = head;
        var times = length - (k % length);
        for (var i = 0; i < times; i++)
        {
            head = head.next;
            prev = prev.next;
        }
        
        prev.next = null;
        return head;
    }
}
