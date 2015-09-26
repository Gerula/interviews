# https://leetcode.com/problems/word-search-ii/
#
#  Given a 2D board and a list of words from the dictionary, find all words in the board.
#
#  Each word must be constructed from letters of sequentially adjacent cell, where "adjacent"
#  cells are those horizontally or vertically neighboring.
#  
#  The same letter cell may not be used more than once in a word. 
#

require 'test/unit'
extend Test::Unit::Assertions

def find_words(board, words)
    trie = words.inject({}){ |acc_trie, word|
        word.chars.each_with_index.inject(acc_trie) { |acc, x|
            acc[x[0]] = {:link => {}, :is_word => x[1] == word.size - 1}
            acc[x[0]][:link]
        }

        acc_trie
    }

    result = []
    for i in 0...board.size
        for j in 0...board[0].size
            search(i, j, board, trie, "", result)
        end
    end

    return result
end

def search(i, j, board, trie, partial, result)
    return if !i.between?(0, board.size - 1) || !j.between?(0, board[0].size - 1)
    current = board[i][j]
    return if trie[current].nil?
    result << partial + current if trie[current][:is_word]
    search(i + 1, j, board, trie[current][:link], partial + current, result)
    search(i, j + 1, board, trie[current][:link], partial + current, result)
    search(i - 1, j, board, trie[current][:link], partial + current, result)
    search(i, j - 1, board, trie[current][:link], partial + current, result)
end

assert_equal(["eat","oath"].sort,
             find_words(
             [
              ['o','a','a','n'],
              ['e','t','a','e'],
              ['i','h','k','r'],
              ['i','f','l','v']
             ],
            ["oath","pea","eat","rain"]).sort)


