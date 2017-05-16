//  https://leetcode.com/problems/binary-search-tree-iterator/
//  https://leetcode.com/submissions/detail/58603101/

public class BSTIterator {
    Stack<TreeNode> stack = new Stack<TreeNode>();
    TreeNode currentNode;

    public BSTIterator(TreeNode root) {
        currentNode = root;
    }

    /** @return whether we have a next smallest number */
    public bool HasNext() {
        return currentNode != null || stack.Any();
    }

    /** @return the next smallest number */
    public int Next() {
        while (currentNode != null)
        {
            stack.Push(currentNode);
            currentNode = currentNode.left;
        }
        
        currentNode = stack.Pop();
        var result = currentNode.val;
        currentNode = currentNode.right;
        return result;
    }
}
