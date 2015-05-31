#  Given a N x M sized Boggle board. Find all of the valid words.


words = ["fox", "mulder", "dana", "scully", "files"]

trie = {}

class TrieNode < Struct.new(:char,:final)
end

words.each { |word|
    partial = trie
    word.chars.each.with_index{|c, index|
        partial[TrieNode.new(c, index == word.size - 1)] ||= {} 
        partial = partial[TrieNode.new(c, index == word.size - 1)] 
    }
}

board = [['f', 'o', 'x', 'm', 'u', 'l'],
         ['o', 'x', 'd', 'a', 'n', 'd'],
         ['o', 'x', 'd', 'a', 'n', 'e'],
         ['o', 'x', 'd', 'a', 'n', 'r'],
         ['o', 'x', 'd', 'a', 'n', 'f'],
         ['o', 'x', 'd', 'a', 'x', 'o']]

def count(position, board, node)
    return 0 if !position[0].between?(0, board.size - 1) ||
                !position[1].between?(0, board[0].size - 1)
    return 0 if node.nil?
    current_trie_letter = node.keys.find{|k| k.char == board[position[0]][position[1]] }
    return 0 if current_trie_letter.nil?
    return (current_trie_letter.final ? 1 : 0) +
           count([position[0], position[1] - 1], board, node[current_trie_letter]) +
           count([position[0], position[1] + 1], board, node[current_trie_letter]) +  
           count([position[0] - 1, position[1]], board, node[current_trie_letter]) +
           count([position[0] + 1, position[1]], board, node[current_trie_letter])
end

count = 0
0.upto(board.size-1).each { |i|
    0.upto(board[i].size-1).each { |j|
        count += count([i, j], board, trie)
    }
}

puts count
