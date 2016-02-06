//  https://leetcode.com/problems/multiply-strings/
//
//  Given two numbers represented as strings, return multiplication of the numbers as a string.
//
//  Note: The numbers can be arbitrarily large and are non-negative.

using System;
using System.Linq;

public class Solution {
    //  
    //  Submission Details
    //  311 / 311 test cases passed.
    //      Status: Accepted
    //      Runtime: 344 ms Pretty slow
    //          
    //          Submitted: 0 minutes ago
    //
    //  https://leetcode.com/submissions/detail/52847898/
    public string Multiply(string num1, string num2) {
        var result = String.Empty;
        num1 = new String(num1.Reverse().ToArray());
        num2 = new String(num2.Reverse().ToArray());

        for (var i = 0; i < num2.Length; i++)
        {
            var current = String.Empty;
            for (var k = 0; k < i; k++)
            {
                current += "0";
            }

            int carry = 0;
            for (var j = 0; j < num1.Length; j++)
            {
                var localResult = carry + (num2[i] - '0') * (num1[j] - '0');
                current += (localResult % 10).ToString();
                carry = localResult / 10;
            }
            
            if (carry != 0)
            {
                current += carry.ToString();
            }
            
            result = Add(current, result, 0).TrimEnd(new [] {'0'}); // Corner case shaming - did not handle trailing zeroes
        }

        return String.IsNullOrEmpty(result) ? "0" : new String(result.Reverse().ToArray()); // Corner case shaming - did not handle empty string when
                                                                                            // handling trailing zeroes
    }

    public String Add(String num1, String num2, int carry)
    {
        if (String.IsNullOrEmpty(num1) && String.IsNullOrEmpty(num2))
        {
            return carry == 0 ? String.Empty : (carry % 10).ToString() + Add(num1, num2, carry / 10);
        }

        var local = carry + 
                    (String.IsNullOrEmpty(num1) ? 0 : num1[0] - '0') +
                    (String.IsNullOrEmpty(num2) ? 0 : num2[0] - '0');

        if (String.IsNullOrEmpty(num1))
        {
            return (local % 10).ToString() + Add(num1, num2.Substring(1), local / 10);
        }

        if (String.IsNullOrEmpty(num2))
        {
            return (local % 10).ToString() + Add(num1.Substring(1), num2, local / 10);
        }

        return (local % 10).ToString() + Add(num1.Substring(1), num2.Substring(1), local / 10);
    }

    static void Main()
    {
        Console.WriteLine(new Solution().Multiply("2", "3"));
        Console.WriteLine(new Solution().Multiply("20", "3"));
        Console.WriteLine(new Solution().Multiply("3", "6"));
        Console.WriteLine(new Solution().Multiply("11", "323"));
        Console.WriteLine(new Solution().Multiply("113", "0"));
    }
}
