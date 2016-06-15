//  https://leetcode.com/problems/verify-preorder-serialization-of-a-binary-tree/
//  One way to serialize a binary tree is to use pre-order traversal.
//  When we encounter a non-null node, we record the node's value.
//  If it is a null node, we record using a sentinel value such as #.
//
//  Given a string of comma separated values, verify whether it is a correct preorder traversal serialization of a binary tree.
//  Find an algorithm without reconstructing the tree.
//
//  https://leetcode.com/submissions/detail/64360559/
//
//  Submission Details
//  150 / 150 test cases passed.
//      Status: Accepted
//      Runtime: 136 ms
//          
//          Submitted: 0 minutes ago
public class Solution {
    public bool IsValidSerialization(string preorder) {
        var degree = 1;
        foreach (var token in preorder.Split(new [] {','}, StringSplitOptions.RemoveEmptyEntries)) {
            if (--degree < 0) {
                return false;
            }
            
            if (token != "#") {
                degree += 2;
            }
        }
        
        return degree == 0;
    }
}
