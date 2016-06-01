//  https://www.hackerrank.com/challenges/caesar-cipher-1?h_r=next-challenge&h_v=zen
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static char RotateLetter(char c, int k) {
        char start = Char.IsUpper(c) ? 'A' : 'a';
        return (char)(start + (c - start + k) % 26);
    }
    
    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string s = Console.ReadLine();
        int k = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(
            new String(
                s.Select(x => Char.IsLetter(x) ? 
                              RotateLetter(x, k) :
                              x)
                 .ToArray()));
    }
}

