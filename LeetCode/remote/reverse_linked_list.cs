//  https://leetcode.com/problems/reverse-linked-list/
//  https://leetcode.com/submissions/detail/58189146/
 
public class Solution {
    public ListNode ReverseList(ListNode head) {
        if (head == null || head.next == null)
        {
            return head;
        }
        
        var next = ReverseList(head.next);
        head.next.next = head;
        head.next = null;
        return next;
    }
}

//  https://leetcode.com/submissions/detail/58187645/
public class Solution {
    public ListNode ReverseList(ListNode head) {
        ListNode prev = null;
        while (head != null)
        {
            var next = head.next;
            head.next = prev;
            prev = head;
            head = next;
        }
        
        return prev;
    }
}
