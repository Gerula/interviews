//  https://leetcode.com/problems/remove-linked-list-elements/

public class Solution {
    //  
    //  Submission Details
    //  63 / 63 test cases passed.
    //      Status: Accepted
    //      Runtime: 176 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public ListNode RemoveElements(ListNode head, int val) {
        if (head == null) 
        {
            return head;
        }

        head.next = RemoveElements(head.next, int val);
        return head.val == val ? head.next : head;
    }

