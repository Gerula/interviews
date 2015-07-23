// https://leetcode.com/submissions/detail/33889944/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode SortedListToBST(ListNode head) {
        return Magic(ref head, 0, GetLength(head) - 1);
    }
    
    public TreeNode Magic(ref ListNode node, int low, int high) {
        if (low > high) {
            return null;
        }
        
        int mid = low + (high - low) / 2;
        TreeNode left = Magic(ref node, low, mid - 1);
        int value = node.val;
        node = node.next;
        TreeNode right = Magic(ref node, mid + 1, high);
        
        return new TreeNode(value) { left = left, right = right };
   } 
    
    public int GetLength(ListNode head) {
        int count = 0;
        for (; head != null; count++, head = head.next) {}
        return count;
    }
}
