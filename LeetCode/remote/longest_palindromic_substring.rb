#   https://leetcode.com/problems/longest-palindromic-substring/
#
#   Given a string S, find the longest palindromic substring in S. You may assume that the maximum length of S is 1000,
#   and there exists one unique longest palindromic substring.

#   https://leetcode.com/submissions/detail/54658367/
def longest_palindrome(s)
    max = ""
    0.upto(s.size - 1).each { |i|
        odd = palindrome(s, i, i)
        even = palindrome(s, i, i + 1)
        
        return s if odd.size == s.size || even.size == s.size
        max = odd if odd.size > max.size
        max = even if even.size > max.size
    }

    max    
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

#   DP TLE
def longest_palindrome(s)
    return s if s.to_s.nil?
    palind = Array.new(s.size) {
        Array.new(s.size)
    }  
    
    0.upto(s.size - 1).each { |i|
        palind[i][i] = true
    }
    
    max = s[0]
    0.upto(s.size - 1).each { |i|
        2.upto(s.size - i) { |j|
            if j == i + 1
                palind[i][i + 1] = s[i] == s[i + 1]
            else
                palind[i][j] = s[i] == s[j] && palind[i + 1][j - 1]
            end
            
            max = s[i, j] if palind[i][j] && s[i, j].size > max.size
        }
    }
    
    max
end

