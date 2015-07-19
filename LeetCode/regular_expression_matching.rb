# '.' Matches any single character.
# '*' Matches zero or more of the preceding element.
#
# The matching should cover the entire input string (not partial).
#
# The function prototype should be:
# bool isMatch(const char *s, const char *p)
#
# Some examples:
# isMatch("aa","a") → false
# isMatch("aa","aa") → true
# isMatch("aaa","aa") → false
# isMatch("aa", "a*") → true
# isMatch("aa", ".*") → true
# isMatch("ab", ".*") → true
# isMatch("aab", "c*a*b") → true

# 445 / 445 test cases passed.
#   Status: Accepted
#   Runtime: 140 ms
#       
#       Submitted: 0 minutes ago
#

def is_match(s, p)
    dp = Array.new(s.size + 1).map { |x|
        Array.new(p.size + 1).map { |y|
            false
        }
    }

    dp[0][0] = true
    for i in 0..s.size
        for j in 1..p.size
            if p[j - 1] != "*"
                dp[i][j] = i > 0 && dp[i - 1][j - 1] && (s[i - 1] == p[j - 1] || p[j - 1] == ".")
            else
                dp[i][j] = dp[i][j - 2] || (i > 0 && dp[i-1][j] && (s[i-1] == p[j-2] || p[j-2] == '.'))
            end
        end
    end

    return dp[s.size][p.size]
end

 [{:s => "aa", :p => "a", :m => false},
  {:s => "aa", :p => "aa", :m => true},
  {:s => "aaa", :p => "aa", :m => false},
  {:s => "aa", :p => "a*", :m => true},
  {:s => "aa", :p => ".*", :m => true},
  {:s => "ab", :p => ".*", :m => true},
  {:s => "aab", :p => "c*a*b", :m => true}].each { |x|
        puts "#{x.inspect} - #{is_match(x[:s], x[:p])}" 
  }
