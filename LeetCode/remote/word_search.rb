#   https://leetcode.com/problems/word-search/
#
#    Given a 2D board and a word, find if the word exists in the grid.
#
#    The word can be constructed from letters of sequentially adjacent cell,
#    where "adjacent" cells are those horizontally or vertically neighboring.
#    The same letter cell may not be used more than once. 
#   https://leetcode.com/submissions/detail/53886542/
#   You are here!
#   Your runtime beats 50.00% of rubysubmissions.
#   Even Steven!
#
#   Submission Details
#   87 / 87 test cases passed.
#       Status: Accepted
#       Runtime: 564 ms
#           
#           Submitted: 0 minutes ago

# @param {Character[][]} board
# @param {String} word
# @return {Boolean}
def exist(board, word, line = 0, col = 0, pos = 0, start = true)
    if start
        for i in 0...board.size
            for j in 0...board[0].size
                return true if exist(board, word, i, j, 0, false)
            end
        end
        
        return false
    end
    
    return false if !line.between?(0, board.size - 1) ||
                    !col.between?(0, board[0].size - 1) ||
                    word[pos] != board[line][col]
    
    board[line][col] = 0
    result = pos + 1 == word.size ||
             exist(board, word, line + 1, col, pos + 1, false) ||
             exist(board, word, line - 1, col, pos + 1, false) ||
             exist(board, word, line, col + 1, pos + 1, false) ||
             exist(board, word, line, col - 1, pos + 1, false)
    board[line][col] = word[pos]
    return result
end

#   https://leetcode.com/submissions/detail/60788361/
#
#   Submission Details
#   87 / 87 test cases passed.
#       Status: Accepted
#       Runtime: 541 ms
#           
#           Submitted: 0 minutes ago
# @param {Character[][]} board
# @param {String} word
# @return {Boolean}
def exist(board, word)
    return false if board.size == 0
    (0...board.size).each { |i|
        (0...board[0].size).each { |j|
            return true if (exists(board, i, j, word, 0))
        }
    }
    
    return false
end

def exists(board, i, j, word, pos)
    return false if !i.between?(0, board.size - 1) ||
                    !j.between?(0, board[0].size - 1) ||
                    word[pos] != board[i][j]
    
    marker, board[i][j] = board[i][j], 0
    result = pos == word.size - 1 ||
             exists(board, i + 1, j, word, pos + 1) ||
             exists(board, i - 1, j, word, pos + 1) ||
             exists(board, i, j + 1, word, pos + 1) ||
             exists(board, i, j - 1, word, pos + 1)
    board[i][j] = marker
    return result
end
