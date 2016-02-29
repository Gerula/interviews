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
