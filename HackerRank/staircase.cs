//  https://www.hackerrank.com/challenges/staircase

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        var n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(
            String.Join(
                Environment.NewLine,
                Enumerable
                .Range(1, n)
                .Select(x => 
                        String.Join(String.Empty, Enumerable.Repeat(' ', n - x)) +
                        String.Join(String.Empty, Enumerable.Repeat('#', x)))));
        
    }
}

