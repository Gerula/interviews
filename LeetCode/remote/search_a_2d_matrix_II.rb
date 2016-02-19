#   https://leetcode.com/problems/search-a-2d-matrix-ii/
#   Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:
#
#   Integers in each row are sorted in ascending from left to right.
#   Integers in each column are sorted in ascending from top to bottom.
#
#   https://leetcode.com/submissions/detail/53871886/
#
#   Submission Details
#   127 / 127 test cases passed.
#       Status: Accepted
#       Runtime: 324 ms
#           
#           Submitted: 3 minutes ago
#   You are here!
#   Your runtime beats 90.00% of rubysubmissions.

# @param {Integer[][]} matrix
# @param {Integer} target
# @return {Boolean}
def search_matrix(matrix, target)
    row = 0
    column = matrix[0].size - 1
    while row < matrix.size && column >= 0
        return true if matrix[row][column] == target
        if matrix[row][column] < target
            row += 1
        else
            column -= 1
        end
    end
    
    return false
end
