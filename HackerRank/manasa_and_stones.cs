//  https://www.hackerrank.com/challenges/manasa-and-stones
//  3/12 pass - 5 points - something about garbage collector can't do something something ahahahhahaa

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
