//  https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
//  Given an array where elements are sorted in ascending order, convert it to a height balanced BST.
//  https://leetcode.com/submissions/detail/63245936/
//
//  Submission Details
//  32 / 32 test cases passed.
//      Status: Accepted
//      Runtime: 174 ms
//          
//          Submitted: 1 minute ago
public class Solution {
    public TreeNode SortedArrayToBST(int[] nums) {
        return nums.Length == 0 ? 
               null :
               new TreeNode(nums[nums.Length / 2]) {
                   left = SortedArrayToBST(nums.Take(nums.Length / 2).ToArray()),
                   right = SortedArrayToBST(nums.Skip(nums.Length / 2 + 1).ToArray())
               };
    }
}
