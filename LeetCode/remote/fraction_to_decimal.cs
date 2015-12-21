//  https://leetcode.com/problems/fraction-to-recurring-decimal/
//
//  Given two integers representing the numerator and denominator of a fraction, return the fraction in string format.
//
//  If the fractional part is repeating, enclose the repeating part in parentheses.
//
//  For example,
//
//      Given numerator = 1, denominator = 2, return "0.5".
//      Given numerator = 2, denominator = 1, return "2".
//      Given numerator = 2, denominator = 3, return "0.(6)".

using System;
using System.Collections.Generic;
using System.Text;

public class Solution {
    public string FractionToDecimal(int numerator, int denominator) {
        var result = new StringBuilder();
        result.Append((numerator < 0) ^ (denominator < 0) ? "-" : String.Empty);
        result.Append((numerator / denominator).ToString());
        numerator = numerator % denominator;
        if (numerator == 0)
        {
            return result.ToString();
        }

        result.Append(".");

        var hash = new Dictionary<int, int>();
        for (var i = numerator % denominator; i != 0; i %= denominator)
        {
            if (hash.ContainsKey(i))
            {
                result.Insert(hash[i], "(");
                result.Append(")");
                break;
            }

            hash[i] = result.Length;
            i *= 10;
            result.Append((i / denominator).ToString());
        }

        return result.ToString();
    }

    static void Main()
    {
        Console.WriteLine(new Solution().FractionToDecimal(1, 2));
        Console.WriteLine(new Solution().FractionToDecimal(2, 1));
        Console.WriteLine(new Solution().FractionToDecimal(2, 3));
        Console.WriteLine(new Solution().FractionToDecimal(-1, -2147483648));
        Console.WriteLine(new Solution().FractionToDecimal(10, 23));
    }
}
