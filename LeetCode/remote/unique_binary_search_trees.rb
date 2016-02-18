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

# Another way:
# - did not get it, altough we already did that before, right?
# - basically it reduces to F : N -> N, F(x) - number of BSTs with x nodes
#           F(0) = 1
#           F(1) = F(0) * F(n - 1)
#           F(2) = F(1) * F(n - 2)
#           F(3) = F(2) * F(n - 3)

def num_trees(n)
    dp = Array.new(n + 1) { 0 }
    dp[0] = dp[1] = 1
    2.upto(n).each { |i|
        0.upto(i - 1).each { |j|
            dp[i] += dp[j] * dp[i - j - 1]
        }
    }

    dp[n]
end
