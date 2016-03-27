#   https://leetcode.com/problems/edit-distance/
#    Given two words word1 and word2, find the minimum number of steps required to convert word1 to word2. (each operation is counted as 1 step.)
#
#    You have the following 3 operations permitted on a word:
#
#    a) Insert a character
#    b) Delete a character
#    c) Replace a character

require 'test/unit'
extend Test::Unit::Assertions

#   https://leetcode.com/submissions/detail/57443197/
#
#   Submission Details
#   1146 / 1146 test cases passed.
#       Status: Accepted
#       Runtime: 528 ms
#           
#           Submitted: 0 minutes ago
#
def min_distance(word1, word2)
    edit = Array.new(word1.size + 1) {
        Array.new(word2.size + 1)
    }
    
    (0..word1.size).each { |i|
        edit[i][0] = i
    }

    (0..word2.size).each { |i|
        edit[0][i] = i
    }

    (1..word1.size).each { |i|
        (1..word2.size).each { |j|
            if word1[i - 1] == word2[j - 1]
                edit[i][j] = edit[i - 1][j - 1]
            else
                edit[i][j] = 1 + [edit[i - 1][j] || 0, edit[i][j - 1] || 0, edit[i - 1][j - 1] || 0].min
            end
        }
    }

    edit[word1.size][word2.size]
end

assert_same(1, min_distance("", "a"))
assert_same(2, min_distance("ab", "bc"))
assert_same(0, min_distance("abc", "abc"))
assert_same(0, min_distance("", ""))
assert_same(3, min_distance("abc", "def"))
assert_same(1, min_distance("abc", "acc"))
