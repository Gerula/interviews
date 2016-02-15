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
