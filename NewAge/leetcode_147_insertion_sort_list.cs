//  https://leetcode.com/problems/insertion-sort-list/
//  https://leetcode.com/submissions/detail/87817044/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode InsertionSortList(ListNode head) {
        var dummy = new ListNode(int.MinValue);
        var node = head;
        while (node != null) {
            var nextNode = node.next;
            var insert = dummy;
            while (insert.next != null && insert.next.val < node.val) {
                insert = insert.next;
            }

            node.next = insert.next;
            insert.next = node;
            node = nextNode;
        }

        return dummy.next;
    }
}
