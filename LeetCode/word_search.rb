grid = [["A", "B", "C", "E"],
        ["S", "F", "C", "S"],
        ["A", "D", "E", "E"]]

def search(s, grid)
    0.upto(grid.size - 1).each { |i|
        0.upto(grid[0].size - 1). each { |j|
            return true if search_rec(grid, s, i, j)
        }
    }
    
    return false
end

def search_rec(grid, s, i, j)
    return false if !i.between?(0, grid.size - 1) || !j.between?(0, grid[0].size - 1)
    return false if s.first != grid[i][j]
    return true if s.size == 1
    aux = grid[i][j]
    grid[i][j] = nil
    result = search_rec(grid, s[1..-1], i + 1, j) ||
             search_rec(grid, s[1..-1], i, j + 1) || 
             search_rec(grid, s[1..-1], i - 1, j) || 
             search_rec(grid, s[1..-1], i, j - 1)
    grid[i][j] = aux
    return result
end

["ABCCED", "SEE", "ABCB"].each { |x|
    puts "#{x} #{search(x.chars, grid)}"
}
