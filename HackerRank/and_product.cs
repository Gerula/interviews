//  https://www.hackerrank.com/challenges/and-product
//  You will be given two integers A and B. You are required to compute the bitwise AND amongst all natural numbers lying between A and B, both inclusiveing System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static long Product(long a, long b) {       
        return b > a ? Product(a >> 1, b >> 1) << 1 : b;
    }    

    /*
    8  = 01000
    9  = 01001
    10 = 01010
    11 = 01011
    12 = 01100
    13 = 01101
    
    8 - 13 = 8
    9 - 13 = 8
    10 -13 = 8
    11 -13 = 8
    12 -13 = 12
    */
    
    static void Main(String[] args) {
        var count = int.Parse(Console.ReadLine());
        for (var i = 0; i < count; i++) {
            var values = Console
                         .ReadLine()
                         .Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                         .Select(x => Int64.Parse(x))
                         .ToArray();

            Console.WriteLine(Product(values[0], values[1]));
        }
    }
}

