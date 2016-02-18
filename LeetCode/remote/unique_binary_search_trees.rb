#   https://leetcode.com/problems/unique-binary-search-trees/
#
#   Given n, how many structurally unique BST's (binary search trees) that store values 1...n?
#
#   For example,
#   Given n = 3, there are a total of 5 unique BST's. 

#   TLE
def num_trees(n)
    trees(1, n)
end

#   https://leetcode.com/submissions/detail/53789799/
#   
#   Submission Details
#   19 / 19 test cases passed.
#       Status: Accepted
#       Runtime: 84 ms
#           
#           Submitted: 0 minutes ago
#
#   Pulled off a poor man's DP. It's so beautiful it hurts.
def trees(low, high, cache)
    return 1 if low >= high
    cache["#{low}-#{high}"] ||= low.upto(high).map { |x| trees(low, x - 1, cache) * trees(x + 1, high, cache) }.inject(:+)
end
