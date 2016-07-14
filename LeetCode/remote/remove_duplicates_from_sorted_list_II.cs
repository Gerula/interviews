//  https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/
//   Given a sorted linked list, delete all nodes that have duplicate numbers, leaving only distinct numbers from the original list.
//
//   For example,
//   Given 1->2->3->3->4->4->5, return 1->2->5.
//   Given 1->1->1->2->3, return 2->3. 
//
//   https://leetcode.com/submissions/detail/67082686/
//
//   Submission Details
//   166 / 166 test cases passed.
//      Status: Accepted
//      Runtime: 171 ms
//          
//          Submitted: 9 hours, 19 minutes ago
public class Solution {
    public ListNode DeleteDuplicates(ListNode head) {
        if (head == null || head.next == null) {
            return head;
        }
        
        if (head.val == head.next.val) {
            while (head.next != null && head.val == head.next.val) {
                head = head.next;
            }
            
            return DeleteDuplicates(head.next);
        }
        
        head.next = DeleteDuplicates(head.next);
        return head;
    }
}
