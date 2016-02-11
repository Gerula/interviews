#   https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/
#
#    Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.
#
#    According to the definition of LCA on Wikipedia:
#    “The lowest common ancestor is defined between two nodes v and w as the lowest node in T that has both v and w
#    as descendants (where we allow a node to be a descendant of itself).” 

#   
#   Submission Details
#   31 / 31 test cases passed.
#       Status: Accepted
#       Runtime: 140 ms
#           
#           Submitted: 0 minutes ago
#
#   https://leetcode.com/submissions/detail/53164176/

def lowest_common_ancestor(root, p, q)
    return root if root.nil? || root == p || root == q
    left = lowest_common_ancestor(root.left, p, q)
    right = lowest_common_ancestor(root.right, p, q)
    return root if left != nil && right != nil
    return left.nil? ? right : left
end

