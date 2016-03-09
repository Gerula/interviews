#   https://leetcode.com/problems/number-of-islands/
#   Given a 2d grid map of '1's (land) and '0's (water), count the number of islands.
#   An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically.
#   You may assume all four edges of the grid are all surrounded by water.
#   https://leetcode.com/submissions/detail/55767227/
#
#   Submission Details
#   45 / 45 test cases passed.
#       Status: Accepted
#       Runtime: 200 ms
#           
#           Submitted: 0 minutes ago
def num_islands(grid)
    count = 0
    (0...grid.size).each { |i|
        (0...grid.first.size).each { |j|
            next if grid[i][j] == '0'
            count += 1
            fill(grid, i, j)
        }
    }
    
    count
end

def fill(grid, i, j)
    return if !(i.between?(0, grid.size - 1) && j.between?(0, grid.first.size - 1)) ||
               grid[i][j] == '0'
               
    grid[i][j] = '0'
    fill(grid, i + 1, j)
    fill(grid, i - 1, j)
    fill(grid, i, j + 1)
    fill(grid, i, j - 1)
end
