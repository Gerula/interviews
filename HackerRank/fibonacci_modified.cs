//  https://www.hackerrank.com/challenges/fibonacci-modified

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static decimal Fib(decimal a, decimal b, decimal idx) {
        idx -= 2;
        decimal c = 0;
        while (idx-- > 0) {
            c = b * b + a;
            a = b;
            b = c;
        }
        
        return c;
    }
    
    static void Main(String[] args) {
        var input = Console
                    .ReadLine()
                    .Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => Decimal.Parse(x))
                    .ToArray();
        Console.WriteLine(Fib(input[0], input[1], input[2]));
    }
}
