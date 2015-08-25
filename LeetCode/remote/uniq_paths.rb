# Follow up for "Unique Paths":
#
# Now consider if some obstacles are added to the grids. How many unique paths would there be?
#
# An obstacle and empty space is marked as 1 and 0 respectively in the grid.
#
# For example,
#
# There is one obstacle in the middle of a 3x3 grid as illustrated below.
#
# [
#   [0,0,0],
#   [0,1,0],
#   [0,0,0]
# ]
#
#       The total number of unique paths is 2.
#
#       Note: m and n will be at most 100.
#
# https://leetcode.com/submissions/detail/37499452/
#
# 43 / 43 test cases passed.
#   Status: Accepted
#   Runtime: 108 ms
#       
#       Submitted: 0 minutes ago
# You are here!
# Your runtime beats 0.00% of ruby coders. <- LoL ( ͡° ͜ʖ ͡°)

def unique_paths_with_obstacles(obstacle_grid)
    return 0 if obstacle_grid[0][0] == 1
    obstacle_grid[0][0] = 1

    for i in 0...obstacle_grid.size
        for j in 0...obstacle_grid.first.size
            next if i == 0 && j == 0
            if obstacle_grid[i][j] == 1
                obstacle_grid[i][j] = 0
                next
            end

            obstacle_grid[i][j] = (i > 0 && obstacle_grid[i - 1][j] >= 0 ? obstacle_grid[i - 1][j] : 0) + 
                                  (j > 0 && obstacle_grid[i][j - 1] >= 0 ? obstacle_grid[i][j - 1] : 0)
        end
    end
    
    puts obstacle_grid.inspect
    return obstacle_grid[obstacle_grid.size - 1][obstacle_grid[0].size - 1]
end

puts (unique_paths_with_obstacles(
    [
        [0,0,0],
        [0,1,0],
        [0,0,0]
    ]
))
    
