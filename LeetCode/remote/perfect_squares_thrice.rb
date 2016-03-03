#   https://leetcode.com/problems/perfect-squares/
#
#   Stack level too deep
# @param {Integer} n
# @return {Integer}
def num_squares(n, hash = nil)
    hash ||= {}
    return hash[n] if hash[n]
    if n < 2
        hash[n] = n
        return hash[n]
    end
    
    hash[n] = (1..Math.sqrt(n)).map { |x| 1 + num_squares(n - x * x, hash) }.min
    return hash[n]
end

# TLE
def num_squares(n, hash = nil)
    dp = Array.new(n + 1)
    dp[0] = 0
    (1..n).each { |i|
        dp[i] = (1..Math.sqrt(i)).map { |j|
            1 + dp[i - j * j]
        }.min
    }
    
    dp[n]
end
