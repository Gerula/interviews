#   https://leetcode.com/problems/minimum-path-sum/
#   Given a m x n grid filled with non-negative numbers,
#   find a path from top left to bottom right which minimizes the sum of all numbers along its path.
#
#   Note: You can only move either down or right at any point in time.
#   https://leetcode.com/submissions/detail/55326347/
#
#   Submission Details
#   61 / 61 test cases passed.
#       Status: Accepted
#       Runtime: 136 ms
#           
#           Submitted: 0 minutes ago
def min_path_sum(grid)
    return 0 if grid.nil? || grid.empty?
    n = grid.size
    m = grid.first.size
    infinity = 2 ** (0.size * 8 - 1)
    (n - 1).downto(0) { |i|
        (m - 1).downto(0) { |j|
            next if i == n - 1 && j == m - 1
            down = i == n - 1 ? infinity : grid[i + 1][j]
            right = j == m - 1 ? infinity : grid[i][j + 1]
            grid[i][j] += [down, right].min
        }
    }
    
    grid[0][0]
end
