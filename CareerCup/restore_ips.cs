//  https://leetcode.com/problems/restore-ip-addresses/
//
//  Given a string containing only digits, restore it by returning all possible valid IP address combinations.
//
//  For example:
//  Given "25525511135",
//
//  return ["255.255.11.135", "255.255.111.35"]. (Order does not matter) 

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    //  
    //  Submission Details
    //  147 / 147 test cases passed.
    //      Status: Accepted
    //      Runtime: 576 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //          After fierce battle - the slowest solution in the OJ
    public IList<string> RestoreIpAddresses(string s) {
        var result = new List<String>();
        Restore(s, 0, new List<int>(), result);
        return result;
    }

    public void Restore(String s, int position, List<int> partial, List<string> result)
    {
        if (position == s.Length && partial.Count == 4)
        {
            result.Add(String.Join(".", partial));
            return;
        }

        if (position == s.Length || partial.Count > 4)
        {
            return;
        }

        var maxLen = s[position] == '0' ? 1 : 4;
        for (var i = 1; i <= maxLen && position + i <= s.Length; i++)
        {
            var number = int.Parse(s.Substring(position, i));
            if (number < 256)
            {
                partial.Add(number);
                Restore(s, position + i, partial, result);
                partial.RemoveAt(partial.Count - 1);
            }
        }
    }

    static void Main()
    {
        Console.WriteLine(String.Join(", ", new Solution().RestoreIpAddresses("25525511135")));
        Console.WriteLine(String.Join(", ", new Solution().RestoreIpAddresses("0000"))); // ARC - always remember cornercases
    }
}
