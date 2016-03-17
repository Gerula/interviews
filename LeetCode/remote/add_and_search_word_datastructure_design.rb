#   https://leetcode.com/problems/add-and-search-word-data-structure-design/
#    Design a data structure that supports the following two operations:
#
#    void addWord(word)
#    bool search(word)
#
#    search(word) can search a literal word or a regular expression string containing only letters a-z or .. A . means it can represent any one letter.
#
#   https://leetcode.com/submissions/detail/56424028/
#
#   Submission Details
#   13 / 13 test cases passed.
#       Status: Accepted
#       Runtime: 1744 ms
#           
#           Submitted: 1 minute ago
class WordDictionary
    def add_word(word)
        @trie ||= {}
        word.chars.reduce(@trie) { |acc, x|
            acc[x] ||= {}
            acc[x]
        }[:end] = true
    end

    def search(word, trie = {})
        trie = @trie if trie == {}
        return false if trie.nil?
        return !trie[:end].nil? if word.to_s.empty?
        return (trie.keys - [:end]).reduce(false) { |acc, x|
            acc || search(word[1..-1], trie[x])
        } if word[0] == "."
        return false if trie[word[0]].nil?
        return search(word[1..-1], trie[word[0]])
    end
To https://github.com/Gerula/interviews.git
   63e01b1..3c4d4b2  master -> master
