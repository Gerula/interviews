#   https://leetcode.com/problems/maximal-square/
#
#    Given a 2D binary matrix filled with 0's and 1's, find the largest square containing all 1's and return its area.
#   https://leetcode.com/submissions/detail/53964916/
#
#   Submission Details
#   67 / 67 test cases passed.
#       Status: Accepted
#       Runtime: 300 ms
#           
#           Submitted: 0 minutes ago

def maximal_square(matrix)
    return 0 if matrix.nil? || matrix.empty?
    n = matrix.size
    m = matrix[0].size
    dp = Array.new(n) {
            Array.new(m) {
                0
            }
         }
    
    (0...n).to_a
    .product((0...m).to_a)
    .select { |i, j| matrix[i][j] != '0' }
    .map { |i, j|
        l = j == 0 ? 0 : dp[i][j - 1]
        u = i == 0 ? 0 : dp[i - 1][j]
        ul = i == 0 && j == 0 ? 0 : dp[i - 1][j - 1]
        dp[i][j] = [l, u, ul].min + 1
        dp[i][j] * dp[i][j]
    }
    .max || 0
end
