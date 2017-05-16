#   https://leetcode.com/problems/unique-paths-ii/
#   Follow up for "Unique Paths":
#
#   Now consider if some obstacles are added to the grids. How many unique paths would there be?
#
#   An obstacle and empty space is marked as 1 and 0 respectively in the grid.
#   https://leetcode.com/submissions/detail/56823863/
#
#   Submission Details
#   43 / 43 test cases passed.
#       Status: Accepted
#       Runtime: 85 ms
#           
#           Submitted: 0 minutes ago
def unique_paths_with_obstacles(obstacle_grid)
    (0...obstacle_grid.size).each { |i|
        (0...obstacle_grid[0].size).each { |j|
            if obstacle_grid[i][j] == 1
                obstacle_grid[i][j] = 0
                next
            end
            
            if i == 0 && j == 0
                obstacle_grid[i][j] = 1
                next
            end
            
            obstacle_grid[i][j] = (i > 0 && obstacle_grid[i - 1][j] > 0 ? obstacle_grid[i - 1][j] : 0) +
                                  (j > 0 && obstacle_grid[i][j - 1] > 0 ? obstacle_grid[i][j - 1] : 0)
        }
    }
    
    obstacle_grid[-1][-1]
end
