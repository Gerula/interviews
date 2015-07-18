#  Given a string s, partition s such that every substring of the partition is a palindrome.
#
#  Return the minimum cuts needed for a palindrome partitioning of s.
#
#  For example, given s = "aab",
#  Return 1 since the palindrome partitioning ["aa","b"] could be produced using 1 cut. 
#

def min_cut(s)
    palindrome = Array.new(s.size + 1).map { |x| 
        Array.new(s.size + 1).map { |y|
            false
        }
    }

    dp = []
    0.upto(s.size) { |i|
        dp[i] = i - 1
    }

    2.upto(s.size).each { |i|
        (i - 1).downto(0).each { |j|
            if s[i - 1] == s[j] && ( i - 1 - j < 2 || palindrome[j + 1, i - 1])
                palindrome[j][i] = true
                dp[i] = [dp[i], dp[j] + 1].min
            end
        }
    }

    return dp[s.size]
end

puts min_cut("aab")
