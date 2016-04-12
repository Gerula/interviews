//  https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/
//   Given a sorted linked list, delete all nodes that have duplicate numbers,
//   leaving only distinct numbers from the original list. 
//   https://leetcode.com/submissions/detail/58844735/
//
//   Submission Details
//   166 / 166 test cases passed.
//      Status: Accepted
//      Runtime: 152 ms
//          
//          Submitted: 0 minutes ago
//  You are here!
//  Your runtime beats 95.74% of csharpsubmissions.

public class Solution {
    public ListNode DeleteDuplicates(ListNode head) {
        var dummy = new ListNode(-1) { next = head };
        var last = dummy;
        var it = head;
        while (it != null)
        {
            while (it.next != null && it.val == it.next.val)
            {
                it = it.next;
            }
            
            if (last.next == it)
            {
                last = last.next;
            }
            else
            {
                last.next = it.next;
            }
            
            it = it.next;
        }
        
        return dummy.next;
    }
}
