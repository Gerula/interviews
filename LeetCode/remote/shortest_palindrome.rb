#   https://leetcode.com/problems/shortest-palindrome/
#   Given a string S, you are allowed to convert it to a palindrome by adding characters in front of it.
#   Find and return the shortest palindrome you can find by performing this transformation. 

require 'test/unit'
extend Test::Unit::Assertions

def shortest_palindrome(s)
    idx = 0
    (1..s.size).each { |i|
        idx = [idx, i].max if s[0, i] == s[0, i].reverse
    }

    s[idx..-1].reverse + s
end

assert("aaacecaaa" == shortest_palindrome("aacecaaa"))
assert("dcbabcd" == shortest_palindrome("abcd"))
