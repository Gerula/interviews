using System;

class Program {
    
    static bool Search(char[][] grid, int line, int column, String word, int position) {
        if (!(0 <= line && line < grid.Length && 0 <= column && column < grid[0].Length)) {
            return false;
        }

        char current = grid[line][column];

        if (current != word[position]) {
            return false;
        }
        
        if (position == word.Length - 1) {
            return true;
        }

        grid[line][column] = '*';
        bool result = (Search(grid, line + 1, column, word, position + 1) ||
                       Search(grid, line - 1, column, word, position + 1) ||
                       Search(grid, line, column + 1, word, position + 1) ||
                       Search(grid, line, column - 1, word, position + 1));

        grid[line][column] = current;
        return result;
    }

    static void Main() {
        char[][] grid = new char[][] { 
            new char[4] {'a', 'b', 'c', 'e' },
            new char[4] {'s', 'f', 'c', 's' },
            new char[4] {'a', 'd', 'e', 'e' }
        };

        string[] words = new string[] { "abcced", "see", "abcb" };
        foreach (string word in words) { 
            bool found = false;
            for (int i = 0; i < grid.Length && !found; i++) {
                for (int j = 0; j < grid[0].Length && !found; j++) {
                    if (Search(grid, i, j, word, 0)) {
                        Console.WriteLine("Found {0}", word);
                        found = true;
                    }
                }
            }

            if (!found) {
                Console.WriteLine("Not found {0}", word);
            }
        }
    }
}
