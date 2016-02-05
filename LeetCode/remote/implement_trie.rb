#   https://leetcode.com/problems/implement-trie-prefix-tree/
#   
#   Implement a trie with insert, search, and startsWith methods. 

# Shit.. I'm forgetting Ruby :(
# 
# Submission Details
# 14 / 14 test cases passed.
#   Status: Accepted
#   Runtime: 360 ms
#       
#       Submitted: 1 minute ago
# 
# https://leetcode.com/submissions/detail/52735582/
#
class TrieNode
    # Initialize your data structure here.
    def initialize
        @next = {}
        @word = ""
    end
    
    attr_reader :next
    attr_accessor :word
end

class Trie
    def initialize
        @root = TrieNode.new
    end

    # @param {string} word
    # @return {void}
    # Inserts a word into the trie.
    def insert(word)
        last = word.chars.inject(@root){ |acc, x|
            acc.next[x] ||= TrieNode.new
            acc.next[x]
        }
        
        last.word = word
    end

    # @param {string} word
    # @return {boolean}
    # Returns if the word is in the trie.
    def search(word)
        prefix = search_prefix(word)
        return !prefix.nil? && prefix.word == word
    end

    # @param {string} prefix
    # @return {boolean}
    # Returns if there is any word in the trie
    # that starts with the given prefix.
    def starts_with(prefix)
        !search_prefix(prefix).nil?
    end
    
    def search_prefix(prefix)
        it = @root
        prefix.chars.each { |x|
            it = it.next[x]
            break if it.nil?
        }
        
        return it
    end
end

# Your Trie object will be instantiated and called as such:
# trie = Trie.new
# trie.insert("somestring")
# trie.search("key")
