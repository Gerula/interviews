// https://leetcode.com/problems/sqrtx/
//
// Implement int sqrt(int x).
//
// Compute and return the square root of x.
//

using System;

public class Solution {
    public int MySqrt(int x) {
        var low = 0;
        var high = x - 1;
        while (low < high)
        {
            var mid = low + (high - low) / 2;
            var result = mid * mid;
            if (result == x)
            {
                return mid;
            }
            else if (result < x)
            {
                low = mid;
            }
            else
            {
                high = mid - 1;
            }
        }

        return low;
    }

    static void Main()
    {
        var c = new Solution();
        Console.WriteLine(c.MySqrt(4));
        Console.WriteLine(c.MySqrt(16));
        Console.WriteLine(c.MySqrt(81));
        Console.WriteLine(c.MySqrt(82));
    }
}
