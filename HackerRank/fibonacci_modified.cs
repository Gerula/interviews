//  https://www.hackerrank.com/challenges/fibonacci-modified

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

class Solution {
    static BigInteger Fib(BigInteger a, BigInteger b, BigInteger idx) {
        idx -= 2;
        BigInteger c = 0;
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
                    .Select(x => BigInteger.Parse(x))
                    .ToArray();
        Console.WriteLine(Fib(input[0], input[1], input[2]));
    }
}
