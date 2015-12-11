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
    // "9371597631128776948387197132267188677349946742344217846154932859125134924241649584251978418763151253"
    //
    // Time limit exceeded - lol of course
    public int NumDecodings(string s) {
        if (String.IsNullOrEmpty(s))
        {
            return 1;
        }

        var sum = 0;
        if (s[0] != '0')
        {
            sum += NumDecodings(s.Substring(1));
        }

        if (s.Length > 1 && int.Parse(s.Substring(0, 2)) < 27)
        {
            sum += NumDecodings(s.Substring(2));
        }

        return sum;
    }

    static void Main()
    {
        var s = new Solution();
        // 1 2 2 6
        // 12 2 6
        // 12 26
        // 1 2 26
        // 1 22 6
        foreach (var t in new [] { "12", "1226" })
        {
            Console.WriteLine("{0} - {1}", t, s.NumDecodings(t));
        }
    }
}
