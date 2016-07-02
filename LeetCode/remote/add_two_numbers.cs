//  https://leetcode.com/problems/add-two-numbers/
//  You are given two linked lists representing two non-negative numbers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.
//
//  Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
//  Output: 7 -> 0 -> 8
//
//
//  Submission Details
//  1556 / 1556 test cases passed.
//      Status: Accepted
//      Runtime: 200 ms
//          
//          Submitted: 1 minute ago
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2, int? remainder = null) {
        if (l1 == null && l2 == null) {
            if (remainder == null) {
                return null;
            }
            
            return new ListNode(remainder.Value);
        }
        
        int one, two;
        l1 = Advance(l1, out one);
        l2 = Advance(l2, out two);
        var sum = one + two + (remainder == null ? 0 : remainder.Value);
        return new ListNode(sum % 10) {
            next = AddTwoNumbers(l1, l2, (sum / 10 == 0) ? (int?) null : sum / 10)
        };
    }
    
    private static ListNode Advance(ListNode l, out int val) {
        val = 0;
        if (l != null) {
            val = l.val;
            l = l.next;
        }
        
        return l;
    }
}
