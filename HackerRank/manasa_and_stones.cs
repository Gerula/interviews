//  https://www.hackerrank.com/challenges/manasa-and-stones
//  4/12 pass - 8 points 

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    
    static IEnumerable<int> Process(int n, int a, int b) {
        return Process(0, n, a, b).Distinct().OrderBy(x => x);
    }
    
    static IEnumerable<int> Process(int current, int n, int a, int b) {
        if (n == 1) {
            return Enumerable.Repeat(current, 1);
        }
        
        return Process(current + a, n - 1, a, b).Concat(Process(current + b, n - 1, a, b));
    }

    static IEnumerable<int> ProcessEnumerable(int n, int a, int b) {
        if (a == b) {
            yield return a * (n - 1);
            yield break;
        }
        
        var start = a * (n - 1);
        var end = b * (n - 1);
        while (start <= end) {
            yield return start;
            start += Math.Abs(b - a);
        }
    }
    
    static void Main(String[] args) {
        var t = int.Parse(Console.ReadLine());
        for (var i = 0; i < t; i++) {
            Console.WriteLine(String.Join(" ", Process(
                int.Parse(Console.ReadLine()),
                int.Parse(Console.ReadLine()),
                int.Parse(Console.ReadLine()))));
        }
    }
}
