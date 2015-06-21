using System;
using System.Collections.Generic;
using System.Linq;

class Trie {
    class Node {
        public String Word { get; set; }
        public bool IsFinal { get { return Word != null; }}
        public Dictionary<char, Node> edges = new Dictionary<char, Node> ();
    }

    private Node Root = new Node();

    public void Add(String word) {
        Node iterator = Root;
        for (int i = 0; i < word.Length; i++) {
            Node current;
            if (!iterator.edges.TryGetValue(word[i], out current)) {
                current = new Node();
                if (i == word.Length - 1) {
                    current.Word = word;
                }

                iterator.edges.Add(word[i], current);
            }
            
            iterator = current;
        }
    }

    public void Search(char[][] grid) {
        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[0].Length; j++) {
                Search(grid, i, j, Root);
            }
        }
    }

    private void Search(char[][] grid, int line, int column, Node node) {
        if (!(0 <= line && line < grid.Length && 0 <= column && column < grid[0].Length))
        {
            return;
        }

        char current = grid[line][column];
        if (!node.edges.Keys.Contains(current)) {
            return;
        }

        node = node.edges[current];

        if (node.IsFinal) {
            Console.WriteLine("Found {0} ", node.Word);
        }

        grid[line][column] = '*';
        Search(grid, line + 1, column, node);
        Search(grid, line - 1, column, node);
        Search(grid, line, column + 1, node);
        Search(grid, line, column - 1, node);
        grid[line][column] = current;
    }
}

class Program {
    static void Main() {
        char[][] grid = new char[][] { 
              new char[] {'o','a','a','n'},
              new char[] {'e','t','a','e'},
              new char[] {'i','h','k','r'},
              new char[] {'i','f','l','v'}
        };

        Trie trie = new Trie();
        foreach (string word in new List<String> {"oath", "pea", "eat", "rain"}) {
            trie.Add(word);
        }

        trie.Search(grid);
    }
}
