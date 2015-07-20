# Surrounded Regions Total Accepted: 32567 Total Submissions: 221727
#
# Given a 2D board containing 'X' and 'O', capture all regions surrounded by 'X'.
#
# A region is captured by flipping all 'O's into 'X's in that surrounded region.
#
# For example,
#
# X X X X
# X O O X
# X X O X
# X O X X
#
# After running your function, the board should be:
#
# X X X X
# X X X X
# X X X X
# X O X X
#
# 58 / 58 test cases passed.
#   Status: Accepted
#   Runtime: 572 ms
#       
#       Submitted: 0 minutes ago
#
#       Slow as fuck!
#

# wrote this directly in the browser. Had a lot of trouble with the o - O - 0 fuckery but managed to get it right afterwards. Not the most efficient.

def solve(board)
    if !board.any?
        return
    end
    
    0.upto(board.size - 1).each { |i|
        fill(i, 0, board, 'O', '1')
        fill(i, board[0].size - 1, board, 'O', '1')
    }
    
    0.upto(board[0].size - 1).each { |i|
        fill(0, i, board, 'O', '1')
        fill(board.size - 1, i, board, 'O', '1')
    }
    
    1.upto(board.size - 1).each { |i|
        1.upto(board[0].size - 1).each { |j|
            fill(i, j, board, 'O', 'X')
        }
    }
    
    0.upto(board.size - 1).each { |i|
        fill(i, 0, board, '1', 'O')
        fill(i, board[0].size - 1, board, '1', 'O')
    }
    
    0.upto(board[0].size - 1).each { |i|
        fill(0, i, board, '1', 'O')
        fill(board.size - 1, i, board, '1', 'O')
    }
    
    return
end

def fill(i, j, board, target, char)
    stack = [[i,j]]
    while stack.any?
        i, j = stack.pop
        if i.between?(0, board.size - 1) && j.between?(0, board[0].size - 1) && board[i][j] == target
            board[i][j] = char
            stack.push([i + 1, j])
            stack.push([i - 1, j])
            stack.push([i, j + 1])
            stack.push([i, j - 1])
        end
    end
end

