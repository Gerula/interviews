# Wrote this one directly in the browser
#
# Search a 2D Matrix Total Accepted: 46469 Total Submissions: 147207
#
# Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:
#
#     Integers in each row are sorted from left to right.
#         The first integer of each row is greater than the last integer of the previous row.
#
#         For example,
#
#         Consider the following matrix:
#
#         [
#           [1,   3,  5,  7],
#           [10, 11, 16, 20],
#           [23, 30, 34, 50]
#         ]
#
#         Given target = 3, return true.
#
# 134 / 134 test cases passed.
#   Status: Accepted
#   Runtime: 100 ms
#       
#       Submitted: 1 minute ago
#

def search_matrix(matrix, target)
    return false if matrix.empty? || matrix[0].empty?
    n, m = matrix.size, matrix[0].size
    line = 0
    column = m - 1
    while line.between?(0, n - 1) && column.between?(0, m - 1)
      if matrix[line][column] == target
            return true
      end
                                         
      if matrix[line][column] > target
          column -= 1
      else
          line += 1
      end
    end

    return false
end
