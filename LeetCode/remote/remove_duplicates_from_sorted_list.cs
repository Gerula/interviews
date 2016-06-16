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

//  https://leetcode.com/submissions/detail/64406454/
//
//  Submission Details
//  164 / 164 test cases passed.
//      Status: Accepted
//      Runtime: 168 ms
//          
//          Submitted: 0 minutes ago
public class Solution {
    public ListNode DeleteDuplicates(ListNode head) {
        if (head == null || head.next == null) {
            return head;
        }

        head.next = DeleteDuplicates(head.next);

        if (head.val == head.next.val) {
            return head.next;
        }
        
        return head;
    }
}

//  
//  Submission Details
//  164 / 164 test cases passed.
//      Status: Accepted
//      Runtime: 164 ms
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
        var dummy = new ListNode(int.MaxValue);
        var it = dummy;
        while (head != null)
        {
            var next = head.next;
            if (it.val != head.val)
            {
                it.next = head;
                it = it.next;
                it.next = null;
            }
            
            head = next;
        }
        
        return dummy.next;
    }
}
