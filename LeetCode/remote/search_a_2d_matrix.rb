#   https://leetcode.com/problems/search-a-2d-matrix/
#
#   Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:
#
#   Integers in each row are sorted from left to right.
#   The first integer of each row is greater than the last integer of the previous row.
#   https://leetcode.com/submissions/detail/53871278/
#
#   Submission Details
#   134 / 134 test cases passed.
#       Status: Accepted
#       Runtime: 72 ms
#           
#           Submitted: 0 minutes ago
# @param {Integer[][]} matrix
# @param {Integer} target
# @return {Boolean}
def search_matrix(matrix, target)
    row = 0
    column = matrix[0].size - 1
    while row < matrix.size && column >=0
        return true if matrix[row][column] == target
        if matrix[row][column] > target
            column -= 1
        else
            row += 1
        end
    end
    
    return false
end

