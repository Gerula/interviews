//  https://leetcode.com/problems/decode-ways/
//
//   A message containing letters from A-Z is being encoded to numbers using the following mapping:
//
//   'A' -> 1
//   'B' -> 2
//   ...
//   'Z' -> 26
//
//   Given an encoded message containing digits, determine the total number of ways to decode it.
//
//   For example,
//   Given encoded message "12", it could be decoded as "AB" (1 2) or "L" (12).
//
//   The number of ways decoding "12" is 2. 

using System;

public class Solution {
    public int NumDecodings(string s) {
        var num = 0;
        CountDecoding(s, ref num);
        return num;
    }

    public void CountDecoding(string s, ref int num)
    {
        if (String.IsNullOrEmpty(s))
        {
            num++;
            return;
        }

        if (s[0] != '0')
        {
            CountDecoding(s.Substring(1), ref num);
        }

        if (s.Length > 1 && int.Parse(s.Substring(0, 2)) < 26)
        {
            CountDecoding(s.Substring(2), ref num);
        }
    }

    static void Main()
    {
        var s = new Solution();
        foreach (var t in new [] { "12", "1226" })
        {
            Console.WriteLine("{0} - {1}", t, s.NumDecodings(t));
        }
    }
}
