#   https://leetcode.com/problems/count-complete-tree-nodes/
#   Given a complete binary tree, count the number of nodes.
#   https://leetcode.com/submissions/detail/55725484/
#
#   Submission Details
#   18 / 18 test cases passed.
#       Status: Accepted
#       Runtime: 328 ms
#           
#           Submitted: 0 minutes ago
def count_nodes(root)
    return 0 if root.nil?
    left, right = measure(root)
    return 2 ** left - 1 if left == right
    return 1 + count_nodes(root.left) + count_nodes(root.right)
end

def measure(root)
    right = 0
    left = 0
    right_it = root
    left_it = root
    while left_it || right_it
        if right_it
            right += 1
            right_it = right_it.right
        end
        if left_it
            left += 1
            left_it = left_it.left
        end
    end
    
    [left, right]
end
