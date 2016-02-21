//  https://leetcode.com/problems/linked-list-cycle/
//   Given a linked list, determine if it has a cycle in it. 
//   https://leetcode.com/submissions/detail/54107644/
//
//   Submission Details
//   16 / 16 test cases passed.
//      Status: Accepted
//      Runtime: 164 ms
//          
//          Submitted: 2 hours, 59 minutes ago

public class Solution {
    public bool HasCycle(ListNode head) {
        if (head == null)
        {
            return false;
        }
        
        var slow = head;
        var fast = head.next;
        while (slow != null && fast != null && fast.next != null && fast != slow)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        
        return fast == slow;
    }
}
