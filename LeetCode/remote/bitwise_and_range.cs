//  https://leetcode.com/problems/bitwise-and-of-numbers-range/
//
//  Given a range [m, n] where 0 <= m <= n <= 2147483647, return the bitwise AND of all numbers in this range, inclusive.
//
//  For example, given the range [5, 7], you should return 4. 

using System;
using System.Linq;

public class Solution {
    //  Runtime Error Message: Line 3: System.ArgumentOutOfRangeException: Argument is out of range.
    //  Last executed input: 
    //  0
    //  2147483647 
    public int RangeBitwiseAnd(int m, int n) {
        return Enumerable.Range(m, (n - m) + 1).Aggregate(255, (acc, x) => acc & x);
    }

    //  TLE
    //
    //  Submission Result: Time Limit Exceeded
    //  Last executed input: 
    //  0
    //  2147483647 
    public int RangeBitwiseAnd2(int m, int n) {
        var result = m;
        for (var i = m + 1; i <= n; i++)
        {
            result &= i;
        }

        return result;
    }

    //  
    //  Submission Details
    //  8266 / 8266 test cases passed.
    //      Status: Accepted
    //      Runtime: 144 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public int RangeBitwiseAnd3(int m, int n) {
        return n > m ? RangeBitwiseAnd3(m / 2, n / 2) << 1 : m;
    }

    static void Main()
    {
        Console.WriteLine(new Solution().RangeBitwiseAnd(5, 7));
        Console.WriteLine(new Solution().RangeBitwiseAnd2(5, 7));
        Console.WriteLine(new Solution().RangeBitwiseAnd3(5, 7));
    }
}
