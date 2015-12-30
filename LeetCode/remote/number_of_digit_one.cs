//  https://leetcode.com/problems/number-of-digit-one/
//
//  Given an integer n, count the total number of digit 1 appearing in all non-negative integers less than or equal to n.
//
//  For example:
//  Given n = 13,
//  Return 6, because digit 1 occurred in the following numbers: 1, 10, 11, 12, 13. 

using System;
using System.Linq;

public class Solution {
    //  
    //  Submission Details
    //  40 / 40 test cases passed.
    //      Status: Accepted
    //      Runtime: 48 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //          https://leetcode.com/submissions/detail/49287808/
    //
    //          Need to book some time to go over the general form of this problem
    public int CountDigitOne(int n) 
    {
        var remainder = 0;
        var acc = 0;
        var index = 0;
        var factor = 1;
        var count = 0;
        while (n > 0)
        {
            remainder = n % 10;
            n /= 10;
            if (remainder == 1)
            {
                count += index + acc + 1;
            }
            else if (remainder > 1)
            {
                count += remainder * index + factor;
            }

            acc += remainder * factor;
            index += 9 * index + factor;
            factor *= 10;
        }

        return count;
    }

    public int NaiveCount(int n)
    {
        return Enumerable
               .Range(1, n)
               .Select(x => x.ToString().Count(y => y == '1'))
               .Sum();
    }

    static void Main()
    {
        var s = new Solution();
        for (var i = 1; i < 10000; i++)
        {
            if (s.CountDigitOne(i) != s.NaiveCount(i))
            {
                throw new Exception(String.Format("Idiot {2} : {0} - {1}", s.CountDigitOne(i), s.NaiveCount(i), i));
            }
        }
    }
}
