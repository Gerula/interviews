# Given a matrix of m x n elements (m rows, n columns), return all elements of the matrix in spiral order. 
#

grid = [[1, 2, 3, 4, 5],
        [7, 8, 9, 1, 6],
        [6, 6, 7, 2, 7],
        [5, 5, 4 ,3, 8],
        [4, 3, 2, 1, 9]]

def spiral(grid)
    directions = [[0, 1], [1, 0], [0, -1], [-1, 0]]
    direction = directions.first
    current_pos = [0, 0]
    direction = 0
    (grid.size ** 2).times {
        print "#{grid[current_pos[0]][current_pos[1]]} "
        grid[current_pos[0]][current_pos[1]] = -1
        
        i = 0
        while !(current_pos[0] + directions[direction][0]).between?(0, grid.size - 1) ||
              !(current_pos[1] + directions[direction][1]).between?(0, grid.size - 1) ||
              (grid[current_pos[0] + directions[direction][0]][current_pos[1] + directions[direction][1]] == -1)
            i += 1
            break if i > directions.size
            direction = (direction + 1) % directions.size
        end

        current_pos[0] += directions[direction][0]
        current_pos[1] += directions[direction][1]
    }
end

spiral(grid)
puts
