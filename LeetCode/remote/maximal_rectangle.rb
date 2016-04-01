#   https://leetcode.com/problems/maximal-rectangle/
#   Given a 2D binary matrix filled with 0's and 1's, find the largest rectangle containing all ones and return its area. 
require 'test/unit'
extend Test::Unit::Assertions

# @param {Character[][]} matrix
# # @return {Integer}
def maximal_rectangle(matrix)
    n = matrix.size
    return 0 if n == 0
    m = matrix[0].size
    return 0 if m == 0
    left = []
    top = []
    max_kek = 0
    (0...n).each { |i|
        top[i], left[i] = [], []
        (0...m).each { |j|
            next if matrix[i][j] == '0'
            top[i][j] = i > 0 && matrix[i - 1][j] == '1' ? top[i - 1][j] + 1 : 1
            left[i][j] = j > 0 && matrix[i][j - 1] == '1' ? left[i][j - 1] + 1 : 1
            top[i][j] = [top[i][j], top[i][j - 1] || top[i][j]].min
            max_kek = [max_kek, left[i][j] * top[i][j]].max
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
