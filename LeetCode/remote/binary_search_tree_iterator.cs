//  https://leetcode.com/problems/binary-search-tree-iterator/
//
//  Implement an iterator over a binary search tree (BST). Your iterator will be initialized with the root node of a BST.
//
//  Calling next() will return the next smallest number in the BST.
//
//  Note: next() and hasNext() should run in average O(1) time and uses O(h) memory, where h is the height of the tree.
//

/**
 * Definition for binary tree
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

//  https://leetcode.com/submissions/detail/52811506/
//
//
//  Submission Details
//  61 / 61 test cases passed.
//      Status: Accepted
//      Runtime: 496 ms
//          
//          Submitted: 0 minutes ago
//
//  You are here!
//  Your runtime beats 83.33% of csharp submissions.
public class BSTIterator {
    private TreeNode _current;
    private TreeNode _result;
    private Stack<TreeNode> _stack;
    
    public BSTIterator(TreeNode root) {
        _current = root;
        _stack = new Stack<TreeNode>();
    }

    /** @return whether we have a next smallest number */
    public bool HasNext() {
        while (_stack.Count != 0 || _current != null)
        {
            if (_current == null)
            {
                _current = _stack.Pop();
                _result = _current;
                _current = _current.right;
                return true;
            }
            else
            {
                _stack.Push(_current);
                _current = _current.left;
            }
        }
        
        return false;
    }

    /** @return the next smallest number */
    public int Next() {
        return _result.val;
    }
}

/**
 * Your BSTIterator will be called like this:
 * BSTIterator i = new BSTIterator(root);
 * while (i.HasNext()) v[f()] = i.Next();
 */
