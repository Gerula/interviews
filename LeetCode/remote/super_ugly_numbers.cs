// https://leetcode.com/problems/super-ugly-number/
//
//  Write a program to find the nth super ugly number.
//
//  Super ugly numbers are positive numbers whose all prime factors are in the given prime list primes of size k.
//  For example, [1, 2, 4, 7, 8, 13, 14, 16, 19, 26, 28, 32] is the sequence of the first 12 super ugly numbers
//  given primes = [2, 7, 13, 19] of size 4. 
//
// The solution is good but one test cases in the OJ fails as it there is an int overflow.

using System;
using System.Linq;

public class Solution {
    public int NthSuperUglyNumber(int n, int[] primes) {
        var counts = new int[primes.Length];
        var result = new int[n];
        if (n <= 1)
        {
            return 1;
        }

        result[0] = 1;

        var i = 1;
        while (i < n)
        {
            var min = int.MaxValue;
            var minIdx = -1;
            for (var k = 0; k < primes.Length; k++)
            {
                var val = result[counts[k]] * primes[k];
                if (val < min)
                {
                    min = val;
                    minIdx = k;
                }
            }

            result[i] = min;
            counts[minIdx]++;
            i += result[i] == result[i - 1] ? 0 : 1;
        }

        return result[n - 1];
    }

    static void Main()
    {
        var c = new Solution();
        var primes = new [] { 2, 7, 13, 19 };
        for (var i = 0; i < 14; i++)
        {
            Console.WriteLine(c.NthSuperUglyNumber(i, primes));
        }
    }
}
