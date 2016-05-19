//  https://www.hackerrank.com/challenges/floyd-city-of-blinding-lights
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static void Floyd(int[,] a) {
        for (var k = 1; k < a.GetLength(0); k++) {
            for (var i = 1; i < a.GetLength(0); i++) {
                for (var j = 1; j < a.GetLength(0); j++) {
                    if (a[i, k] * a[k, j] != 0 &&
                        (a[i, j] == 0 || a[i, j] > a[i, k] + a[k, j])) {
                        a[i, j] = a[i, k] + a[k, j];
                    }
                }
            }
        }
    }
    
    static void Main(String[] args) {
        var s = ReadInts();
        var n = s[0]; var m = s[1];
        var matrix = new int[n + 1, n + 1];
        for (var i = 0; i < m; i++) {
            s = ReadInts();
            matrix[s[0], s[1]] = s[2];
        }
        
        Floyd(matrix);
        var queries = ReadInts()[0];
        for (var i = 0; i < queries; i++) {
            s = ReadInts();
            if (s[0] == s[1]) {
                Console.WriteLine(0);
            } else {
                Console.WriteLine(matrix[s[0], s[1]] == 0 ? -1 : matrix[s[0], s[1]]);
            }
        }
    }
    
    static int[] ReadInts() {
        return Console.ReadLine().Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
    }
}
