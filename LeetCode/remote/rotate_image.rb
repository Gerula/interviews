#   https://leetcode.com/problems/rotate-image/
#
#   You are given an n x n 2D matrix representing an image.
#
#   Rotate the image by 90 degrees (clockwise).
#
#   Follow up:
#   Could you do this in-place?
#   
#   https://leetcode.com/submissions/detail/53447922/
#
#   Submission Details
#   20 / 20 test cases passed.
#       Status: Accepted
#       Runtime: 72 ms
#           
#           Submitted: 0 minutes ago

# @param {Integer[][]} matrix
# @return {Void} Do not return anything, modify matrix in-place instead.
def rotate(matrix)
    n = matrix.size
    for i in 0...n
        for j in 0...(n - i)
            matrix[i][j], matrix[n - j - 1][n - i - 1] = matrix[n - j - 1][ n - i - 1], matrix[i][j]
        end
    end
    puts "#{matrix}"
    for i in 0...(n / 2)
        for j in 0...n
            matrix[i][j], matrix[n - i - 1][j] = matrix[n - i - 1][j], matrix[i][j]
        end
    end
end

#   1 2 3    9 6 3    7 4 1
#   4 5 6 -> 8 5 2 -> 8 5 2
#   7 8 9    7 4 1    9 6 3


