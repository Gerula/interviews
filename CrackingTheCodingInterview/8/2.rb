# Imagine a robot sitting on the upper left hand corner of an NxN grid. The robot can only move in two directions: right and down. How many possible paths are there for the robot?
#

grid = [[0, 0, 1, 0, 0, 0, 0],
        [0, 0, 1, 0, 0, 0, 0],
        [0, 0, 0, 0, 1, 1, 0],
        [0, 1, 1, 0, 1, 1, 0],
        [0, 1, 1, 0, 1, 1, 0],
        [0, 0, 0, 0, 1, 1, 0],
        [0, 0, 0, 0, 0, 0, 0]]

def find_paths(grid, src, dest, currentPath)
    return if !src[0].between?(0, 6) || !src[1].between?(0, 6) || grid[src[0], src[1]] == 1 
    currentPath.push(src)
    if src == dest
        currentPath.each { |x|
            print "[#{x[0]} - #{x[1]}] "
        }
        puts
    end
   
    down = [src[0] + 1, src[1]]
    right = [src[0], src[1] + 1] 
    find_paths(grid, down, dest, currentPath) unless currentPath.include?(down)
    find_paths(grid, right, dest, currentPath) unless currentPath.include?(right)
    currentPath.delete(src)
end

find_paths(grid, [0, 0], [6, 6], [])
