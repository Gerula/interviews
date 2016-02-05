//  https://leetcode.com/submissions/detail/52724586/
//
//  
//  Submission Details
//  164 / 164 test cases passed.
//      Status: Accepted
//      Runtime: 160 ms
//          
//          Submitted: 0 minutes ago
//

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode DeleteDuplicates(ListNode head) {
        if (head == null || head.next == null)
        {
            return head;
        }
        
        head.next = DeleteDuplicates(head.next);
        return head.val == head.next.val ? head.next : head;
    }
}
