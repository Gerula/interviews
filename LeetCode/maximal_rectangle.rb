#  Given a 2D binary matrix filled with 0's and 4's, find the largest rectangle containing all ones and return its area. 


grid = [[0, 0, 0, 0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 0, 0, 0],
        [0, 4, 4, 4, 0, 0, 0, 0, 0],
        [0, 4, 4, 4, 0, 0, 0, 0, 0],
        [0, 4, 4, 4, 0, 0, 0, 0, 0],
        [4, 4, 4, 4, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 4, 4, 4, 0, 0],
        [0, 0, 0, 0, 4, 4, 4, 0, 0],
        [0, 0, 0, 0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 4, 0, 0, 0, 0]]

max_grid = Array.new(grid.size) { |x|
    Array.new(grid[0].size) { |y|
        0
    }
}

0.upto(max_grid.size - 1).each { |i|
    max_grid[i][0] = 1 if grid[i][0] == 4
}

0.upto(max_grid[0].size - 1).each { |i|
    max_grid[0][i] = 1 if grid[0][i] == 4
}

max = 0
1.upto(max_grid.size - 1).each { |i|
    1.upto(max_grid[0].size - 1).each { |j|
        if grid[i][j] == 4
            max_grid[i][j] = 1

        else
            max_grid[i][j] = 0
        end
    }
}

max_grid.each { |x|
    puts x.inspect
}
puts max
