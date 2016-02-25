#   https://leetcode.com/problems/word-break/
#
#    Given a string s and a dictionary of words dict, determine if s can be segmented into a space-separated sequence of one or more dictionary words. 

# TLE
def word_break(s, word_dict)
    return s.to_s.empty? || 
           (1..s.size)
           .select { |x| word_dict.include?(s[0, x]) }
           .map { |x| word_break(s[x..-1], word_dict) }
           .inject(:|)
end

# Still TLE
def word_break(s, word_dict, hash = nil)
    return hash[s] if !hash.nil? && !hash[s].nil?
    hash ||= {}
    result = s.to_s.empty? || 
             (1..s.size)
             .select { |x| word_dict.include?(s[0, x]) }
             .map { |x| word_break(s[x..-1], word_dict, hash) }
             .inject(:|)
    hash[s] = result || false
    return hash[s]
end

#   https://leetcode.com/submissions/detail/54508959/
#
#   Submission Details
#   34 / 34 test cases passed.
#       Status: Accepted
#       Runtime: 128 ms
#           
#           Submitted: 0 minutes ago

def word_break(s, word_dict)
    wb = Array.new(s.size + 1) { false }
    wb[0] = true
    0.upto(s.size - 1).each { |i|
        next if !wb[i]
        1.upto(s.size - i).each { |j|
            next if wb[i + j]
            wb[i + j] = word_dict.include?(s[i, j])
        }
    }

    wb[s.size]
end

# Small optimization (old idea of mine on the C# solution)
# to push this solution to the next level
#
# https://leetcode.com/submissions/detail/54509068/
#
# Submission Details
# 34 / 34 test cases passed.
#   Status: Accepted
#   Runtime: 104 ms
#       
#       Submitted: 0 minutes ago
# You are here!
# Your runtime beats 100.00% of rubysubmissions.

def word_break(s, word_dict)
    wb = Array.new(s.size + 1) { false }
    wb[0] = true
    0.upto(s.size - 1).each { |i|
        next if !wb[i]
        current = s[i..-1]
        word_dict.select { |word| current.start_with?(word) }.each { |word|
            wb[i + word.size] = true
        }
    }

    wb[s.size]
end
