// https://leetcode.com/problems/sqrtx/
//
// Implement int sqrt(int x).
//
// Compute and return the square root of x.
//

using System;

public class Solution {
    // 
    // Submission Details
    // 1017 / 1017 test cases passed.
    //  Status: Accepted
    //  Runtime: 64 ms
    //      
    //      Submitted: 0 minutes ago
    public int MySqrt(int x) {
        var low = 0;
        var high = x;
        if (x < 2) 
        {
            return x;
        }

        while (low < high)
        {
            var mid = low + (high - low) / 2;
            if (mid <= x / mid) // Integer overflow. It used to be mid * mid <= x !! Pay attention, you muppet.
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }

        return high - 1;
    }

    public int MySqrt2(int x)
    {
        var root = x;
        while (root > x / root)
        {
            root = (root + x / root) / 2;
        }

        return root;
    }

    static void Main()
    {
        var c = new Solution();
        Console.WriteLine(c.MySqrt(2));
        Console.WriteLine(c.MySqrt(4));
        Console.WriteLine(c.MySqrt(16));
        Console.WriteLine(c.MySqrt(81));
        Console.WriteLine(c.MySqrt(82));
        Console.WriteLine(c.MySqrt(2147483647));
        Console.WriteLine(c.MySqrt2(2));
        Console.WriteLine(c.MySqrt2(4));
        Console.WriteLine(c.MySqrt2(16));
        Console.WriteLine(c.MySqrt2(81));
        Console.WriteLine(c.MySqrt2(82));
        Console.WriteLine(c.MySqrt2(2147483647));
    }
}
