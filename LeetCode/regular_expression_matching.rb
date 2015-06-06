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

def is_match(s, p)
    if s.empty? && p.empty?
        return true
    end

    
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
