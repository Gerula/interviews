// https://leetcode.com/submissions/detail/36702616/

class TrieNode {
    // Initialize your data structure here.
    public Dictionary<char, TrieNode> next = new Dictionary<char, TrieNode>();
    public bool isWord;
        
    public TrieNode() {
 
    }
}

public class Trie {
    private TrieNode root;

    public Trie() {
        root = new TrieNode();
    }

    // Inserts a word into the trie.
    public void Insert(String word) {
        TrieNode iterator = root;
        for (int i = 0; i < word.Length; i++) {
            TrieNode nextNode;
            if (!iterator.next.TryGetValue(word[i], out nextNode)) {
                nextNode = new TrieNode();
                iterator.next[word[i]] = nextNode;
            }
            
            if (i == word.Length - 1) {
                nextNode.isWord = true;
            } 
            
            iterator = nextNode;
        }
    }

    // Returns if the word is in the trie.
    public bool Search(string word) {
        TrieNode iterator = root;
        for (int i = 0; i < word.Length; i++) {
            TrieNode nextNode;
            if (!iterator.next.TryGetValue(word[i], out nextNode)) {
                return false;
            }
            
            if (i == word.Length - 1) {
                return nextNode.isWord;
            } 
            
            iterator = nextNode;
        }
        
        return false;
    }

    // Returns if there is any word in the trie
    // that starts with the given prefix.
    public bool StartsWith(string word) {
        TrieNode iterator = root;
        for (int i = 0; i < word.Length; i++) {
            TrieNode nextNode;
            if (!iterator.next.TryGetValue(word[i], out nextNode)) {
                return false;
            }
          
            iterator = nextNode;
        }
        
        return true;
    }
}

// Your Trie object will be instantiated and called as such:
// Trie trie = new Trie();
// trie.Insert("somestring");
// trie.Search("key");
