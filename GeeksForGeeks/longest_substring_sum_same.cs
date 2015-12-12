//  http://www.geeksforgeeks.org/longest-even-length-substring-sum-first-second-half/
//
//  Given a string ‘str’ of digits, find length of the longest substring of ‘str’, such that the length of the substring is 2k digits and sum of left k digits is equal to the sum of right k digits.
//
//  Examples:
//
//  Input: str = "123123"
//  Output: 6
//  The complete string is of even length and sum of first and second
//  half digits is same
//
//  Input: str = "1538023"
//  Output: 4
//  The longest substring with same first and second half sum is "5380"
//
//  Developer's note: I can't believe the amount of bullshit these people can spew. I wonder where we'll be in a couple of years
//  as I notice the pool of 'new' problems shrink every day and they come up with these bullshit questions. I mean come one
//  the longest substring with even digits where the first half sum equals the second half sum - lol.

using System;

static class Program
{
    static String EqSum(this String s)
    {
        var maxPosition = 0;
        var maxLength = 0;
        var dp = new int[s.Length, s.Length];
        for (var i = 0; i < s.Length; i++)
        {
            dp[i, i] = s[i] - '0';
        }
    
        for (var i = s.Length - 2; i >= 0; i--)
        {
            for (var j = i + 1; j < s.Length; j++)
            {
                var len = j - i + 1;
                if (len % 2 == 0 && dp[i, i + len / 2 - 1] == dp[i + len / 2, j])
                {
                    maxPosition = i;
                    maxLength = len;
                }

                dp[i, j] = dp[i, i + len / 2 - 1] + dp[i + len / 2, j];
            }
        }

        return s.Substring(maxPosition, maxLength);
    }

    static void Main()
    {
        Console.WriteLine("123123".EqSum());
        Console.WriteLine("1538023".EqSum());
    }
}
