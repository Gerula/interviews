//  https://leetcode.com/problems/odd-even-linked-list/
//
//  Given a singly linked list, group all odd nodes together followed by the even nodes.
//  Please note here we are talking about the node number and not the value in the nodes.
//
//  You should try to do it in place. The program should run in O(1) space complexity and O(nodes) time complexity.
//
//  Example:
//  Given 1->2->3->4->5->NULL,
//  return 1->3->5->2->4->NULL.
//
//  Note:
//  The relative order inside both the even and odd groups should remain as it was in the input.
//  The first node is considered odd, the second node even and so on ... 

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode OddEvenList(ListNode head) {
        var oddStart = new ListNode(-1);
        var oddEnd = oddStart;
        var evenStart = new ListNode(-1);
        var evenEnd = evenStart;
        while (head != null)
        {
            if (head.val % 2 == 0)
            {
                evenEnd.next = head;
                evenEnd = evenEnd.next;
            }
            else
            {
                oddEnd.next = head;
                oddEnd = oddEnd.next;
            }
            
            head = head.next;
        }
        
        oddEnd.next = evenStart.next;
        evenEnd.next = null;
        return oddStart.next;
    }
}
