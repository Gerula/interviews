#  Given a binary tree, flatten it to a linked list in-place.
#
#  For example,
#  Given 
#
#         1
#        / \
#       2   5
#      / \   \
#     3   4   6
#
# The flattened tree should look like:
# 
#    1
#     \
#      2
#       \
#        3
#         \
#          4
#           \
#            5
#             \
#              6
#

class TreeNode<Struct.new(:value, :left, :right)
end

tree = TreeNode.new(1,
                TreeNode.new(2,
                         TreeNode.new(3, nil, nil),
                         TreeNode.new(4, nil, nil)),
                TreeNode.new(5,
                         nil,
                         TreeNode.new(6, nil, nil)))

stack = []
root = tree

while stack.any? || !root.nil?
    if root.nil?
        root = stack.pop
        puts root.value
        root = root.right
    else
        stack.push(root)
        root = root.left
    end
end


