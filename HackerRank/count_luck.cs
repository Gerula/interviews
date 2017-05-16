//  https://www.hackerrank.com/challenges/count-luck

//  2 / 16 passed

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Solution {
    static bool Wand(StringBuilder[] a, int guesses) {
        for (var i = 0; i < a.Length; i++) {
            for (var j = 0; j < a[i].Length; j++) {
                if (a[i][j] == 'M' && Wand(a, 0, guesses, i, j, 0)) {
                    return true;
                }
            }
        }
        
        return false; 
    }
    
    static bool Wand(StringBuilder[] a, int guesses, int maxGuesses, int i, int j, int direction) {
        if (0 > i || i >= a.Length ||
            0 > j || j >= a[i].Length ||
            a[i][j] == 'X' ||
            guesses > maxGuesses) {
            return false;
        }
        
        if (a[i][j] == '*') {
            return guesses == maxGuesses;
        }
        
        a[i][j] = 'X';
        var optionsCount = Options(a, i, j);
        var options = optionsCount > 1;
        
        if (optionsCount == 0) {
            return false;
        }
        
        return Wand(a, guesses + (!options || direction == 1 ? 0 : 1), maxGuesses, i - 1, j, 1) ||
               Wand(a, guesses + (!options || direction == 2 ? 0 : 1), maxGuesses, i, j + 1, 2) ||
               Wand(a, guesses + (!options || direction == 3 ? 0 : 1), maxGuesses, i + 1, j, 3) ||
               Wand(a, guesses + (!options || direction == 4 ? 0 : 1), maxGuesses, i, j - 1, 4);
    }
    
    static int Options(StringBuilder[] m, int a, int b) {
        var count = 0;
        if (a - 1 >= 0 && m[a - 1][b] != 'X') {
            count++;
        }
        
        if (b - 1 >= 0 && m[a][b - 1] != 'X') {
            count++;
        }
        
        if (a + 1 < m.Length && m[a + 1][b] != 'X') {
            count++;
        }
        
        if (b + 1 < m[a].Length && m[a][b + 1] != 'X') {
            count++;
        }
        
        return count;
    }
    
    static void Main(String[] args) {
        var count = int.Parse(Console.ReadLine());
        for (var i = 0; i < count; i++) {
            var s = Console.ReadLine().Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(s[0]);
            var m = int.Parse(s[1]);
            var a = new StringBuilder[n];
            for (var k = 0; k < n; k++) {
                a[k] = new StringBuilder(Console.ReadLine());
            }
            
            var guesses = int.Parse(Console.ReadLine());
            Console.WriteLine(Wand(a, guesses) ? "Impressed" : "Oops!");
        }
    }
}
