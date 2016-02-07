//  https://leetcode.com/problems/intersection-of-two-linked-lists/
//
//  Write a program to find the node at which the intersection of two singly linked lists begins.
//
//  
//      If the two linked lists have no intersection at all, return null.
//          The linked lists must retain their original structure after the function returns.
//              You may assume there are no cycles anywhere in the entire linked structure.
//                  Your code should preferably run in O(n) time and use only O(1) memory.
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
    //  
    //  Submission Details
    //  42 / 42 test cases passed.
    //      Status: Accepted
    //      Runtime: 220 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        var first = headA;
        var second = headB;
        var offsetA = 0;
        var offsetB = 0;
        while (first != null || second != null)
        {
            if (first == null)
            {
                offsetB++;
                second = second.next;
            }
            else if (second == null)
            {
                offsetA++;
                first = first.next;
            }
            else
            {
                first = first.next;
                second = second.next;
            }
        }
        
        first = headA;
        second = headB;
        while (offsetA-- > 0)
        {
            first = first.next;
        }
        while (offsetB-- > 0)
        {
            second = second.next;
        }
        
        while (second != first && second != null && first != null)
        {
            first = first.next;
            second = second.next;
        }
        
        return first;
    }
}
