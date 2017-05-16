//  https://www.hackerrank.com/challenges/sansa-and-xor

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static int Sansa(int[] a) {
        if (a.Length % 2 == 0) {
            return 0;
        }
 
        var result = 0;
        for (var i = 0; i < a.Length; i += 2) {
            result ^= a[i];
        }
        
        return result;
    }
    //  [1, 2, 3]
    //  1 2 3 1 2 2 3 1 2 3
    //  1 3 = 2
    //  [4, 5, 7, 5]
    //  4 5 7 5 4 5 5 7 7 5 4 5 7 5 7 5 4 5 7 5
    //  = 0
    //  [1, 2, 3, 4]
    //  1 2 3 4 1 2 2 3 3 4 1 2 3 2 3 4 1 2 3 4
    //  3 4 3 4
    //  [1, 2, 3, 4, 5]
    //  1 2 3 4 5 1 2 2 3 3 4 4 5 1 2 3 2 3 4 3 4 5 1 2 3 4 2 3 4 5 1 2 3 4 5
    //  1 3 5
    //  [1 2 3 4 5 6 7]
    //  1 2 3 4 5 6 7 1 2 2 3 3 4 4 5 5 6 6 7 1 2 3 2 3 4 3 4 5 4 5 6 5 6 7
    //  1 2 3 4 2 3 4 5 3 4 5 6 4 5 6 7
    //  1 2 3 4 5 2 3 4 5 6 3 4 5 6 7
    //  1 2 3 4 5 6 2 3 4 5 6 7
    //  1 2 3 4 5 6 7
    
    //  1 3 5 7
    
    static void Main(String[] args) {
        var inputCount = int.Parse(Console.ReadLine());
        for (var i = 0; i < inputCount; i++) {
            Console.ReadLine();
            Console.WriteLine(
                Sansa(
                    Console
                    .ReadLine()
                    .Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray()));
        }
    }
}
