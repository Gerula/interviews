#   https://leetcode.com/problems/flatten-binary-tree-to-linked-list/
#    Given a binary tree, flatten it to a linked list in-place. 
#    https://leetcode.com/submissions/detail/55048700/
#
#    Submission Details
#    225 / 225 test cases passed.
#       Status: Accepted
#       Runtime: 96 ms
#           
#           Submitted: 0 minutes ago

def flatten(root)
    return nil if root.nil?
    left = root.left
    right = root.right
    root.left = nil
    root.right = nil
    left = flatten(left)
    right = flatten(right)
    root.right = left
    it = root
    while it.right
        it = it.right
    end
    
    it.right = right
    return root
end
