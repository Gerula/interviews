#   https://leetcode.com/problems/shortest-palindrome/
#   Given a string S, you are allowed to convert it to a palindrome by adding characters in front of it.
#   Find and return the shortest palindrome you can find by performing this transformation. 

require 'test/unit'
extend Test::Unit::Assertions

# Memory limit exceeded
def shortest_palindrome(s)
    idx = 0
    (1..s.size).each { |i|
        idx = [idx, i].max if s[0, i] == s[0, i].reverse
    }

    s[idx..-1].reverse + s
end

#   https://leetcode.com/submissions/detail/57364432/
#
#   Submission Details
#   117 / 117 test cases passed.
#       Status: Accepted
#       Runtime: 716 ms
#           
#           Submitted: 0 minutes ago
#
def shortest_palindrome_2(s)
    idx = 0
    front = ""
    back = ""
    (0...s.size).each { |i|
        front = front + s[i]
        back = s[i] + back
        idx = [idx, i].max if front == back
    }

    (s[idx + 1..-1] || "").reverse + s
end

#   https://leetcode.com/submissions/detail/57365892/
#
#   Submission Details
#   117 / 117 test cases passed.
#       Status: Accepted
#       Runtime: 1044 ms
#           
#           Submitted: 0 minutes ago
def shortest_palindrome_3(s)
    idx = 0
    front = 0
    back = 0
    pow = 1
    (0...s.size).each { |i|
        dijit = s[i].ord - 'a'.ord
        front = front * 27 + dijit
        back = back + dijit * pow
        pow *= 27
        idx = [idx, i].max if front == back
    }

    (s[idx + 1..-1] || "").reverse + s
end

assert("aaacecaaa" == shortest_palindrome_3("aacecaaa"))
assert("dcbabcd" == shortest_palindrome_3("abcd"))
assert("aaacecaaa" == shortest_palindrome_2("aacecaaa"))
assert("dcbabcd" == shortest_palindrome_2("abcd"))
assert("aaacecaaa" == shortest_palindrome("aacecaaa"))
assert("dcbabcd" == shortest_palindrome("abcd"))
