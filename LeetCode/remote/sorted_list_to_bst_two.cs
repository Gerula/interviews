//  https://leetcode.com/problems/convert-sorted-list-to-binary-search-tree/
//
//  Given a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.
//
//  Nice one. Did it all in the browser and it got accepted pretty good altough it's the shitty naive version.
//
//  https://leetcode.com/submissions/detail/53503625/
//
//
//  Submission Details
//  32 / 32 test cases passed.
//      Status: Accepted
//      Runtime: 168 ms
//          
//          Submitted: 0 minutes ago
//
//  You are here!
//  Your runtime beats 60.00% of csharp submissions.

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
        if (head == null)
        {
            return null;
        }
        
        if (head.next == null)
        {
            return new TreeNode(head.val);    
        }
        
        var slow = head;
        var pre = slow;
        var fast = head.next;
        while (fast != null && fast.next != null)
        {
            pre = slow;
            slow = slow.next;
            fast = fast.next.next;
        }
        
        var mid = pre.next;
        pre.next = null;
        var result = new TreeNode(mid.val);
        result.left = SortedListToBST(head);
        result.right = SortedListToBST(mid.next);
        return result;
    }
}

//  
//  Submission Details
//  32 / 32 test cases passed.
//      Status: Accepted
//      Runtime: 172 ms
//          
//          Submitted: 0 minutes ago
//
//  https://leetcode.com/submissions/detail/53532814/
//
//  Bullshit! This should be way faster complexity-wise. I would blame the OJ.
public class Solution {
    public TreeNode SortedListToBST(ListNode head) {
        var length = 0;
        for (var it = head; it != null; it = it.next)
        {
            length++;
        }
        
        return SortedListToBST(ref head, 0, length - 1);
    }
    
    public TreeNode SortedListToBST(ref ListNode head, int low, int high)
    {
        if (low > high)
        {
            return null;
        }
        
        var mid = low + (high - low) / 2;
        var left = SortedListToBST(ref head, low, mid - 1);
        var val = head.val;
        head = head.next;
        var right = SortedListToBST(ref head, mid + 1, high);
        return new TreeNode(val) {
            left = left,
            right = right
        };
    }
}
