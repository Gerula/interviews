#   https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/
#   Given preorder and inorder traversal of a tree, construct the binary tree.
#   https://leetcode.com/submissions/detail/55575588/
#
#   Submission Details
#   202 / 202 test cases passed.
#       Status: Accepted
#       Runtime: 184 ms
#           
#           Submitted: 0 minutes ago
def build_tree(preorder, inorder)
    return nil if !preorder || !inorder || preorder.empty? || inorder.empty?
    new = TreeNode.new(preorder.first)
    new.left = build_tree(preorder[1..(inorder.index(preorder.first) + 1)], inorder[0...inorder.index(preorder.first)])
    new.right = build_tree(preorder[(inorder.index(preorder.first) + 1)..-1], inorder[(inorder.index(preorder.first) + 1)..-1])
    new
end
