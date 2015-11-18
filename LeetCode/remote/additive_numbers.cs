// https://leetcode.com/problems/additive-number/
//
// Additive number is a positive integer whose digits can form additive sequence.
//
// A valid additive sequence should contain at least three numbers. Except for the first two numbers, each subsequent number in the sequence must be the sum of the preceding two.
//
// For example:
// "112358" is an additive number because the digits can form an additive sequence: 1, 1, 2, 3, 5, 8.
//
// 1 + 1 = 2, 1 + 2 = 3, 2 + 3 = 5, 3 + 5 = 8
//
// "199100199" is also an additive number, the additive sequence is: 1, 99, 100, 199.
//
// 1 + 99 = 100, 99 + 100 = 199
//
// Note: Numbers in the additive sequence cannot have leading zeros, so sequence 1, 2, 03 or 1, 02, 3 is invalid.
//
// Given a string represents an integer, write a function to determine if it's an additive number.
//
// 
// Submission Details
// 34 / 34 test cases passed.
//  Status: Accepted
//  Runtime: 152 ms
//      
//      Submitted: 0 minutes ago
//

using System;

public class Solution {
    public bool IsAdditiveNumber(string num) {
        for (var i = 1; i < num.Length; i++)
        {
            for (var j = 1; j < num.Length - i; j++)
            {
                var first = long.Parse(num.Substring(0, i));
                var second = long.Parse(num.Substring(i, j));
                if (second.ToString() != num.Substring(i, j))
                {
                    continue;
                }

                var k = i + j;
                while (k < num.Length)
                {
                    var third = first + second;
                    if (!num.Substring(k).StartsWith(third.ToString()))
                    {
                        break;
                    }

                    k += third.ToString().Length;
                    first = second;
                    second = third;
                }

                if (k == num.Length)
                {
                    return true;
                }
            }
        }

        return false;
    }

    static void Main()
    {
        var x = new Solution();
        Console.WriteLine(x.IsAdditiveNumber("112358"));
        Console.WriteLine(x.IsAdditiveNumber("199100199"));
        Console.WriteLine(x.IsAdditiveNumber("19910199"));
        Console.WriteLine(x.IsAdditiveNumber("111122335588143"));
        Console.WriteLine(x.IsAdditiveNumber("123"));
        Console.WriteLine(x.IsAdditiveNumber("1023"));
    }
}
