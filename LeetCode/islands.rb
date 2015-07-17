a = ["11000",
     "11000",
     "00100",
     "00011"]

def num_islands(grid)
    result = 0
    for i in 0..grid.size - 1
     for j in 0..grid[i].size - 1
        if grid[i][j] == "1"
            result += 1
            stack = [[i, j]]
            while stack.any?
                current = stack.pop
                k, l = current
                if k.between?(0, grid.size - 1) && 
                   l.between?(0, grid[0].size - 1) &&
                   grid[k][l] == "1"
                    grid[k][l] = "0"
                    stack.push([k + 1, l])
                    stack.push([k, l + 1])
                    stack.push([k - 1, l])
                    stack.push([k, l - 1])
                end
            end
        end
     end
    end   

    return result
end

puts num_islands(a)
puts num_islands(["11"])
