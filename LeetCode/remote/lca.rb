# https://leetcode.com/submissions/detail/33910954/

# Definition for a binary tree node.
# class TreeNode
#     attr_accessor :val, :left, :right
#     def initialize(val)
#         @val = val
#         @left, @right = nil, nil
#     end
# end

# @param {TreeNode} root
# @param {TreeNode} p
# @param {TreeNode} q
# @return {TreeNode}
def lowest_common_ancestor(root, p, q)
    lca(root, p, q)
end

def lca(root, p, q)
    return root if root == nil || root == p || root == q
    left = lca(root.left, p, q)
    right = lca(root.right, p, q)
    return root if !left.nil? && !right.nil?
    return left.nil? ? right : left
end
