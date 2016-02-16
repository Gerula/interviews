#   https://leetcode.com/problems/interleaving-string/
#
#    Given s1, s2, s3, find whether s3 is formed by the interleaving of s1 and s2.
#
#    For example,
#    Given:
#    s1 = "aabcc",
#    s2 = "dbbca",
#
#    When s3 = "aadbbcbcac", return true.
#    When s3 = "aadbbbaccc", return false. 

# TLE beautiful recursive solution:
def is_interleave(s1, s2, s3)
    return s3.empty? ?
           s2.empty? && s1.empty? :
           !s1.empty? && s1[0] == s1[0] && is_interleave(s1[1..-1], s2, s3[1..-1]) ||
           !s2.empty? && s2[0] == s3[0] && is_interleave(s1, s2[1..-1], s3[1..-1])
end

#   
#   Submission Details
#   101 / 101 test cases passed.
#       Status: Accepted
#       Runtime: 160 ms
#           
#           Submitted: 0 minutes ago
#
#   https://leetcode.com/submissions/detail/53548145/
#   
#   No ranking but I assume it's pretty fucking fast
def is_interleave(s1, s2, s3)
    n = s1.size
    m = s2.size
    return false if s3.size != n + m
    dp = Array.new(n + 1) {
        Array.new(m + 1) {
            false
        }
    }
    
    dp[0][0] = true
    
    for i in 0..n
        for j in 0..m
            next if i == 0 && j == 0
            first = i > 0 && s1[i - 1] == s3[i + j - 1]
            second = j > 0 && s2[j - 1] == s3[i + j - 1]
            dp[i][j] = first && dp[i - 1][j] || second && dp[i][j - 1]
        end
    end
    
    return dp[n][m]
end
