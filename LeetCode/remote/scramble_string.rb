#   https://leetcode.com/problems/scramble-string/
#    Given a string s1, we may represent it as a binary tree by partitioning it to two non-empty substrings recursively. 
#     We say that "rgtae" is a scrambled string of "great".
#
#     Given two strings s1 and s2 of the same length, determine if s2 is a scrambled string of s1. 
#   https://leetcode.com/submissions/detail/56760635/
#
#   Submission Details
#   281 / 281 test cases passed.
#       Status: Accepted
#       Runtime: 134 ms
#           
#           Submitted: 0 minutes ago
#   You are here!
#   Your runtime beats 100.00% of rubysubmissions.
require 'test/unit'
extend Test::Unit::Assertions

def is_scramble(s1, s2)
    n = s1.size
    return true if s1 == s2
    return false if s1.chars.sort != s2.chars.sort
    (1...n).each { |i|
        return true if is_scramble(s1[0...i], s2[0...i]) && is_scramble(s1[i..-1], s2[i..-1])
        return true if is_scramble(s1[0...i], s2[n - i..-1]) && is_scramble(s1[i..-1], s2[0...n - i])
    }

    return false
end

assert(is_scramble("rgtae", "great"))
assert(is_scramble("rgeat", "great"))
assert(is_scramble("a", "a"))
assert(!is_scramble("abc", "dvx"))
assert(is_scramble("abc", "acb"))
assert(is_scramble("sqksrqzhhmfmlmqvlbnaqcmebbkqfy", "abbkyfqemcqnblvqmlmfmhhzqrskqs"), "wtf")
