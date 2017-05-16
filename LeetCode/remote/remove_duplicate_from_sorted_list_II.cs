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

//  https://leetcode.com/submissions/detail/60865948/
//
//  Submission Details
//  166 / 166 test cases passed.
//      Status: Accepted
//      Runtime: 164 ms
//          
//          Submitted: 0 minutes ago
    public ListNode DeleteDuplicates(ListNode head) {
        var dummy = new ListNode(-1) { next = head };
        var dummyIt = dummy;
        var it = head;
        while (it != null)
        {
            if (it.next != null && it.val == it.next.val)
            {
                while (it.next != null && it.val == it.next.val)
                {
                    it = it.next;
                }
            }
            else
            {
                dummyIt.next = it;
                dummyIt = dummyIt.next;
            }
            
            it = it.next;
        }
        
        dummyIt.next = null;
        return dummy.next;
    }

//  https://leetcode.com/submissions/detail/60899154/
//
//  Submission Details
//  166 / 166 test cases passed.
//      Status: Accepted
//      Runtime: 156 ms
//          
//          Submitted: 0 minutes ago
//  You are here!
//  Your runtime beats 91.49% of csharpsubmissions.
public class Solution {
    public ListNode DeleteDuplicates(ListNode head) {
        if (head == null)
        {
            return head;
        }
        
        if (head.next != null && head.val == head.next.val)
        {
            while (head.next != null && head.val == head.next.val)
            {
                head = head.next;
            }
            
            return DeleteDuplicates(head.next);
        }
        
        head.next = DeleteDuplicates(head.next);
        return head;
    }
}
