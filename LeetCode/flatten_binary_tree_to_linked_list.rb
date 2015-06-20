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

def listify(current)
    return if current.nil?
    left = current.left
    right = current.right
    current.left = nil
    current.right = nil
    listify(left)
    listify(right)
    if left
        current.right = left
    end
    it = current
    while current.right
        current = current.right
    end
    current.right = right
end

tree = TreeNode.new(1,
                TreeNode.new(2,
                         TreeNode.new(3, nil, nil),
                         TreeNode.new(4, nil, nil)),
                TreeNode.new(5,
                         nil,
                         TreeNode.new(6, nil, nil)))
def display(tree)
    it = tree
    while it
        print "#{it.value} "
        it = it.right
    end
    puts
end

display(tree)
listify(tree)
display(tree)
