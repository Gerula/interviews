#   https://leetcode.com/problems/decode-ways/
#    A message containing letters from A-Z is being encoded to numbers using the following mapping:
#
#    'A' -> 1
#    'B' -> 2
#    ...
#    'Z' -> 26
#
#    Given an encoded message containing digits, determine the total number of ways to decode it. 

require 'test/unit'
extend Test::Unit::Assertions

# @param {String} s
# # @return {Integer}
def num_decodings(s)
    return 0 if s.to_s.empty?
    return num_decodings(s[1..-1]) if s[0] == '0'
    return 1 + num_decodings(s[1..-1]) + 
           (s.size > 1 && s[0...2].to_i < 27 ? num_decodings(s[2..-1]) : 0)
end

#   https://leetcode.com/submissions/detail/56467066/
#
#   Submission Details
#   259 / 259 test cases passed.
#       Status: Accepted
#       Runtime: 72 ms
#           
#           Submitted: 0 minutes ago
#
def num_dec(s)
    return 0 if s.to_s.empty?
    dp = Array.new(s.size + 1)
    dp[s.size] = 1
    (s.size - 1).downto(0).each { |i|
        dp[i] = s[i] == '0' ? 
                0 :
                dp[i + 1] + (i < s.size && s[i, 2].to_i < 27 ? dp[i + 2] || 0 : 0)
    }

    dp[0]
end

assert_same(2, num_decodings("12"))
assert_same(2, num_dec("12"))
