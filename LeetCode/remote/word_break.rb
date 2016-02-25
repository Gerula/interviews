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
