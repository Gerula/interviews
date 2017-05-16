#   https://leetcode.com/problems/surrounded-regions/
#    Given a 2D board containing 'X' and 'O', capture all regions surrounded by 'X'.
#
#    A region is captured by flipping all 'O's into 'X's in that surrounded region.
#
#    Pretty cute solution but it blows up the stack.
#    Line 15: in `between?': stack level too deep (SystemStackError)
# @param {Character[][]} board
# @return {Void} Do not return anything, modify board in-place instead.
def solve(board)
    return if board.empty?
    (0...board.size)
    .to_a
    .product((0...board.first.size).to_a)
    .each { |l, c|
        next if board[l][c] == 'X'
        dfs(board, l, c)
    }
end

def dfs(board, line, column)
    return false if !line.between?(0, board.size - 1) || !column.between?(0, board.first.size - 1)
    return true if board[line][column] == 'X'
    board[line][column] = 'X'
    good = dfs(board, line - 1, column) &&
           dfs(board, line + 1, column) &&
           dfs(board, line, column - 1) &&
           dfs(board, line, column + 1)
    board[line][column] = 'O' unless good
    return good
end

# It's evolution baby
def solve(board)
    (0...board.size).each { |i|
        (0...board[0].size).each { |j|
            fill(board, i, j)
        }
    }
end

def fill(board, i, j)
    return false if !i.between?(0, board.size - 1) || !j.between?(0, board[0].size - 1)
    return true if board[i][j] == 'X'
    board[i][j] = 'X'
    board[i][j] = '0' if !fill(board, i - 1, j) ||
                         !fill(board, i + 1, j) ||
                         !fill(board, i, j - 1) ||
                         !fill(board, i, j + 1)
end

def solve(board)
    (0...board.size).each { |i|
        (0...board[0].size).each { |j|
            fill(board, i, j) unless board[i][j] == 'X'
        }
    }
end

def fill(board, i, j)
    stack = [[[i, j], [i, j]]]
    should_fill = true
    while stack.any?
        frontier = stack.pop
        current = c(frontier)
        parent = p(frontier)
        if !should_fill
            board[parent[0]][parent[1]] = 'O'
        else
            board[current[0]][current[1]] = 'X'
            (current[0] - 1).upto(current[0] + 1).each { |i|
                (current[1] - 1).upto(current[1] + 1).each { |j|
                    next if i == j
                    should_fill &&= i.between?(0, board.size - 1) && j.between?(0, board[0].size - 1) 
                    next if !should_fill
                    stack.push([[i, j], current])
                }
            }      
        end
        
        board[current[0]][current[1]] = 'O' if !should_fill
    end
end

def p(x)
    return x[1]
end

def c(x)
    return x[0]
end
