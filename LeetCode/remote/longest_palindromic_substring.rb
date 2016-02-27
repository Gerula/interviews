#   https://leetcode.com/problems/longest-palindromic-substring/
#
#   Given a string S, find the longest palindromic substring in S. You may assume that the maximum length of S is 1000,
#   and there exists one unique longest palindromic substring.

#   TLE:

def longest_palindrome(s)
    0.upto(s.size - 1)
    .map { |i| [palindrome(s, i, i), palindrome(s, i, i + 1)] }
    .flatten
    .max { |a, b| a.size <=> b.size }
end

def palindrome(s, low, high)
    while low.between?(0, s.size - 1) &&
          high.between?(0, s.size - 1) &&
          s[low] == s[high]
        low -= 1
        high += 1
    end

    s[low + 1..high - 1]
end
