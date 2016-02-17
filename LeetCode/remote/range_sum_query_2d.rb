#   https://leetcode.com/problems/range-sum-query-2d-immutable/
#
#   Given a 2D matrix matrix, find the sum of the elements inside the rectangle defined
#   by its upper left corner (row1, col1) and lower right corner (row2, col2).

#   https://leetcode.com/submissions/detail/53682219/
#   Basically a remake after a C# classic
#
#   Submission Details
#   12 / 12 test cases passed.
#       Status: Accepted
#       Runtime: 120 ms
#           
#           Submitted: 0 minutes ago
#
class NumMatrix
    # Initialize your data structure here.
    # @param {Integer[][]} matrix
    def initialize(matrix)
        @matrix = []
        return if matrix.nil? || !matrix.any? || !matrix[0].any?
        @n = matrix.size
        @m = matrix[0].size
        column = Array.new(@m + 1) { 0 }
        @matrix = Array.new(@n + 1) {
            Array.new(@m + 1) {
                0
            }
        }

        for i in 1..@n
            for j in 1..@m
                @matrix[i][j] = column[j] + @matrix[i][j - 1] + matrix[i - 1][j - 1]
                column[j] += matrix[i - 1][j - 1]
            end
        end

        puts "#{@matrix}"
    end

    def sum_region(row1, col1, row2, col2)
        return 0 if !@matrix.any?
        return @matrix[row2 + 1][col2 + 1] -
               @matrix[row1][col2 + 1] -
               @matrix[row2 + 1][col1] +
               @matrix[row1][col1]
    end
end

m = NumMatrix.new([[3,0,1,4,2],[5,6,3,2,1],[1,2,0,1,5],[4,1,0,1,7],[1,0,3,0,5]])
puts m.sum_region(2,1,4,3)
puts m.sum_region(1,1,2,2)
puts m.sum_region(1,2,2,4)
