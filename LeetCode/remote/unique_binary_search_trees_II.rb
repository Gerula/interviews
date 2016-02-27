#   https://leetcode.com/problems/unique-binary-search-trees-ii/
#   Given n, generate all structurally unique BST's (binary search trees) that store values 1...n.
#
#   https://leetcode.com/submissions/detail/54709008/
#
#   Submission Details
#   9 / 9 test cases passed.
#       Status: Accepted
#       Runtime: 140 ms
#           
#           Submitted: 0 minutes ago

def generate_trees(n)
    return [] if n == 0
    generate_tree(1, n)
end

def generate_tree(low, high)
    return [nil] if low > high
    low.upto(high).map { |i|
        x = generate_tree(low, i - 1)
        .product(generate_tree(i + 1, high))
        .map { |x, y|
            node = TreeNode.new(i)
            node.left = x
            node.right = y
            node
        }
    }.flatten
end
