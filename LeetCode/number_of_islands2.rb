# Number of islands
# Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. 
# An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
# You may assume all four edges of the grid are all surrounded by water.
 
def fill(grid, position)
    return if !position[0].between?(0, grid.size) ||
           !position[1].between?(0, grid[0].size) ||
           grid[position[0]][position[1]] == 0
 
    grid[position[0]][position[1]] = 0
 
    [[-1, -1], [-1, 0], [-1, 1],
     [ 0, -1],          [ 0, 1],
     [ 1, -1], [ 1, 0], [ 1, 1]].each {|x|
           fill(grid, position.zip(x).map {|y| y.reduce(:+)})
     }
end
 
a = [[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
     [0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0],
     [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
     [0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0],
     [0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0],
     [0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0],
     [0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 0],
     [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
     [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]]
 
islands = 0
(0..a.length-1).each { |i|
    (0..a[i].length-1).each { |j|
        if a[i][j] != 0
            islands += 1
            fill(a, [i, j])
        end
    }
}
 
puts islands
