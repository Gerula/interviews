# https://leetcode.com/problems/word-break-ii/
#

require 'test/unit'
extend Test::Unit::Assertions

# Submission Details
# 29 / 29 test cases passed.
#   Status: Accepted
#   Runtime: 132 ms
#       
#       Submitted: 0 minutes ago
# You are here!
# Your runtime beats 50.00% of ruby submissions. - Even Steven
#
def word_break(s, word_dict)
    result = []
    dictionary = word_dict.inject({}) { |acc, x|
        acc[x] ||= true
        acc
    }

    n = s.size
    can_break = Array.new(n + 1) { false }
    can_break[n] = true
    (n - 1).downto(0).each { |i|
        i.upto(n - 1).each { |j|
            if dictionary[s[i...(j + 1)]] && can_break[j + 1]
                can_break[i] = true
                break
            end
        }
    }

    word_break_helper(s, 0, "", result, dictionary, can_break)

    return result
end

def word_break_helper(s, index, partial, result, dictionary, can_break)
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
                          dictionary,
                          can_break) if dictionary[word] and can_break[i + 1]
        i += 1
    end
end

assert_equal(["cats and dog", "cat sand dog"].sort,
             word_break("catsanddog",
                        ["cat", "cats", "and", "sand", "dog"]).sort)
 
assert_equal([].sort,
             word_break("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab",
                        ["a","aa","aaa","aaaa","aaaaa","aaaaaa","aaaaaaa","aaaaaaaa","aaaaaaaaa","aaaaaaaaaa"]).sort)
