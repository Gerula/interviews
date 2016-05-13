//  https://www.hackerrank.com/challenges/maximizing-xor
//  Given two integers, and , find the maximal value of xor , where and satisfy the following condition:

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
/*
 * Complete the function below.
 */
    static int maxXor(int l, int r) {
        var x = l ^ r;
        var result = 1;
        while (x != 0) {
            result <<= 1;
            x >>= 1;
        }
        
        return result - 1;
    }

    static void Main(String[] args) {
        int res;
        int _l;
        _l = Convert.ToInt32(Console.ReadLine());
        
        int _r;
        _r = Convert.ToInt32(Console.ReadLine());
        
        res = maxXor(_l, _r);
        Console.WriteLine(res);
        
    }
}

