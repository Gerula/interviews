//  https://www.hackerrank.com/challenges/cavity-map
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static string[] ProcessGrid(string[] grid) {
        var n = grid.Length;
        BitArray[] map = Enumerable.Range(0, n).Select(x => new BitArray(n, false)).ToArray();
        
        for (var i = 1; i < n - 1; i++) {
            for (var j = 1; j < n - 1; j++) {
                if (grid[i][j - 1] < grid[i][j] && grid[i][j] > grid[i][j + 1] &&
                    grid[i - 1][j] < grid[i][j] && grid[i][j] > grid[i + 1][j]) {
                    map[i][j] = true;
                }
            }
        }
        
        return grid
               .Select((s, line) => 
                       new String(s.Select((letter, index) => map[line][index] ? 'X' : letter).ToArray()))
               .ToArray();
    }
    
    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] grid = new string[n];
        for(int grid_i = 0; grid_i < n; grid_i++){
           grid[grid_i] = Console.ReadLine();   
        }
        
        Console.WriteLine(String.Join(Environment.NewLine, ProcessGrid(grid)));
    }
}

