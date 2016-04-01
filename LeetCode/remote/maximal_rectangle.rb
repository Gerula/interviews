#   https://leetcode.com/problems/maximal-rectangle/
#   Given a 2D binary matrix filled with 0's and 1's, find the largest rectangle containing all ones and return its area. 
require 'test/unit'
extend Test::Unit::Assertions

#   https://leetcode.com/submissions/detail/57854174/
#
#   Submission Details
#   65 / 65 test cases passed.
#       Status: Accepted
#       Runtime: 232 ms
#           
#           Submitted: 0 minutes ago
#
# @param {Character[][]} matrix
# # @return {Integer}
def maximal_rectangle(matrix)
    n = matrix.size
    return 0 if n == 0
    m = matrix[0].size
    return 0 if m == 0
    top = []
    max_kek = 0
    (0...n).each { |i|
        stack = []
        (0..m).each { |j|
            top[j] = if j < m && matrix[i][j] == '1'
                         (top[j] || 0) + 1
                     else
                         0
                     end

            while stack.any? && top[stack[-1]] >= top[j]
                last = stack.pop
                max_kek = [max_kek, top[last] * (stack.empty? ? j : j - stack[-1] - 1)].max
            end

            stack.push(j)
        }
    }

    max_kek
end

assert_same(4, maximal_rectangle([['0', '1', '1'],
                                  ['0', '1', '1']]))

assert_same(2, maximal_rectangle([['0', '1'],
                                  ['0', '1']]))

assert_same(6, maximal_rectangle(["1101",
                                  "1101",
                                  "1111"]))
                                  
assert_same(6, maximal_rectangle(["1010",
                                  "1011",
                                  "1011",
                                  "1111"]))

assert_same(6, maximal_rectangle([['0', '1', '1', '1'],
                                  ['0', '1', '1', '1']]))

assert_same(10, maximal_rectangle([['0', '0', '1', '1', '1'],
                                   ['0', '0', '0', '1', '1'],
                                   ['1', '1', '0', '0', '1'],
                                   ['1', '1', '0', '1', '0'],
                                   ['1', '1', '0', '1', '1'],
                                   ['1', '1', '0', '1', '1'],
                                   ['1', '1', '0', '1', '1']]))
