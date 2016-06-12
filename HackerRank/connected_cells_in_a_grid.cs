//  https://www.hackerrank.com/challenges/connected-cell-in-a-grid
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static int Areas(int[][] a) {
        var max = 0;
        for (var i = 0; i < a.Length; i++) {
            for (var j = 0; j < a[i].Length; j++) {
                max = Math.Max(max, Search(a, i, j));
            }
        }
        
        return max;
    }
    
    static int Search(int[][] a, int i, int j) {
        if (a[i][j] != 1) {
            return 0;
        }
        
        var count = 1;
        a[i][j] = 0;
        
        for (var line = Math.Max(0, i - 1); line <= Math.Min(a.Length - 1, i + 1); line++) {
            for (var column = Math.Max(0, j - 1); column <= Math.Min(a[line].Length - 1, j + 1); column++) {
                count += Search(a, line, column);
            }            
        }
        return count;
    }
    
    static void Main(String[] args) {
        var n = int.Parse(Console.ReadLine());
        var m = int.Parse(Console.ReadLine());
        var a = new int[n][];
        for (var i = 0; i < n; i++) {
            a[i] = Console.ReadLine().Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        }
        
        Console.WriteLine(Areas(a));
    }
}
