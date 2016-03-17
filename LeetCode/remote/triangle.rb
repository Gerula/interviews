#   https://leetcode.com/problems/triangle/
#   Given a triangle, find the minimum path sum from top to bottom.
#   Each step you may move to adjacent numbers on the row below.
#   https://leetcode.com/submissions/detail/56562228/
#
#   Submission Details
#   43 / 43 test cases passed.
#       Status: Accepted
#       Runtime: 92 ms
#           
#           Submitted: 0 minutes ago
def minimum_total(triangle)
    return triangle[0][0] if triangle.size < 2
    (triangle.size - 2).downto(0).each { |i|
        0.upto(triangle[i].size - 1).each { |j|
            triangle[i][j] += [triangle[i + 1][j], triangle[i + 1][j + 1]].min
        }
    }
    
    triangle[0][0]
end
