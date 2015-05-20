# Number of islands
# Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. 
# An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
# You may assume all four edges of the grid are all surrounded by water.
 
def island?(grid, position)
    return false if !position[0].between?(0, grid.size) ||
                    !position[1].between?(0, grid[0].size) ||
                    grid[position[0]][position[1]] == 0
 
    grid[position[0]][position[1]] = 0
 
    return [[-1, -1], [-1, 0], [-1, 1],
            [ 0, -1],          [ 0, 1],
            [ 1, -1], [ 1, 0], [ 1, 1]].map {|x|
                island?(grid, [position[0] + x[0], position[1] + x[1]])
            }.reduce{|x, y| x || y} || true
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
        islands += 1 if island?(a, [i, j])
    }
}
 
puts islands
