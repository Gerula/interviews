# https://leetcode.com/problems/word-break-ii/
#

require 'test/unit'
extend Test::Unit::Assertions

# This approach exceeds time limit for test #2
def word_break(s, word_dict)
    result = []
    dictionary = word_dict.inject({}) { |acc, x|
        acc[x] ||= true
        acc
    }

    word_break_helper(s, 0, "", result, dictionary)

    return result
end

def word_break_helper(s, index, partial, result, dictionary)
    if index == s.size
        result << partial
        return
    end

    i = index
    word = ""
    while i < s.size
        word += s[i]
        word_break_helper(s,
                          i + 1,
                          partial + (partial.empty? ? "" : " ") + word,
                          result,
                          dictionary) if dictionary[word]
        i += 1
    end
end

assert_equal(["cats and dog", "cat sand dog"].sort,
             word_break("catsanddog",
                        ["cat", "cats", "and", "sand", "dog"]).sort)
 
assert_equal(["cats and dog", "cat sand dog"].sort,
             word_break("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab",
                        ["a","aa","aaa","aaaa","aaaaa","aaaaaa","aaaaaaa","aaaaaaaa","aaaaaaaaa","aaaaaaaaaa"]).sort)
