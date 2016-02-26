#   https://leetcode.com/problems/word-break-ii/
#    Given a string s and a dictionary of words dict, add spaces in s to construct a sentence where each word is a valid dictionary word.
#
#    Return all such possible sentences.
#
#    For example, given
#    s = "catsanddog",
#    dict = ["cat", "cats", "and", "sand", "dog"].
#
#    A solution is ["cats and dog", "cat sand dog"]. 

#   TLE
def word_break(s, word_dict)
    return [""] if s.to_s.empty?
    word_dict
    .select { |x| s.start_with?(x) }
    .map { |x| 
        word_break(s[x.size..-1], word_dict)
        .map { |y| "#{x} #{y}".strip }
    }
    .flatten
end
