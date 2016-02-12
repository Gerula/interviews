#   https://leetcode.com/problems/perfect-squares/
#
#    Given a positive integer n, find the least number of perfect square numbers (for example, 1, 4, 9, 16, ...) which sum to n.
#
#    For example, given n = 12, return 3 because 12 = 4 + 4 + 4; given n = 13, return 2 because 13 = 4 + 9. 

# @param {Integer} n
# @return {Integer}
def num_squares(n)
    0.upto(n).reduce(Array.new(n + 1) { 0 }) { |acc, i|
        acc[i] = 1.upto(Math.sqrt(i)).map { |x| 1 + acc[i - x * x] }.min
        acc[i] ||= 0
        acc
    }[n]
end

# @param {Integer} n
# @return {Integer}
def num_squares(n)
    dp = Array.new(n + 1)
    dp[0] = 0
    for i in 1..n
        dp[i] = n
        j = 1
        while j * j <= i
            dp[i] = [dp[i], dp[i - j * j] + 1].min
            j += 1
        end
    end
    
    dp[n]
end
