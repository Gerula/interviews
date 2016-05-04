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
    
   //   https://leetcode.com/submissions/detail/60699959/
   //
   //   Submission Details
   //   32 / 32 test cases passed.
   //       Status: Accepted
   //       Runtime: 172 ms
   //           
   //           Submitted: 1 minute ago
   //
   public TreeNode SortedListToBST(ListNode head) 
   {
        if (head == null)
        {
            return null;
        }
        
        if (head.next == null)
        {
            return new TreeNode(head.val);
        }
        
        var pre = head;
        var slow = head;
        var fast = head.next;
        while (fast != null && fast.next != null)
        {
            pre = slow;
            slow = slow.next;
            fast = fast.next.next;
        }
        
        var first = head;
        var second = pre.next;
        pre.next = null;
        return new TreeNode(second.val) {
            left = SortedListToBST(first),
            right = SortedListToBST(second.next)
        };
    }

    public int GetLength(ListNode head) {
        int count = 0;
        for (; head != null; count++, head = head.next) {}
        return count;
    }
}
