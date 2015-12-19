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

    //  
    //  Submission Details
    //  63 / 63 test cases passed.
    //      Status: Accepted
    //      Runtime: 172 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public ListNode RemoveElements(ListNode head, int val) 
    {
        var dummy = new ListNode(0) { next = head };
        var it = dummy;

        while (it != null && it.next != null)
        {
            if (it.next.val == val)
            {
                it.next = it.next.next;
            }
            else
            {
                it = it.next;
            }
        }

        return dummy.next;
    }
}
