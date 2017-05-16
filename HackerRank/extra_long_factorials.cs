//  https://www.hackerrank.com/challenges/extra-long-factorials
//  This was moderate? I thought it was superfactorials..

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

class Solution {
    static BigInteger SuperFactorial(int n) {
        return Enumerable
               .Range(1, n)
               .Aggregate(
                  new BigInteger(1),
                  (acc, x) => {
                      return acc * x;
                  });
    }
    
    static void Main(String[] args) {
        Console.WriteLine(SuperFactorial(Convert.ToInt32(Console.ReadLine())));
    }
}

