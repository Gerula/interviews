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

public class Solution {
    //  
    //  Submission Details
    //  147 / 147 test cases passed.
    //      Status: Accepted
    //      Runtime: 524 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  https://leetcode.com/submissions/detail/51306307/
    //
    //  You are here!
    //  Your runtime beats 2.86% of csharp submissions.
    //
    //  What in the fuck?
    public IList<string> RestoreIpAddresses(string s) {
        var result = new List<string>();
        if (s.Length > 12 || s.Length < 4)
        {
            return result;
        }

        for (var i = 1; i <= 3; i++)
        {
            var first = s.Substring(0, i);
            if (first[0] == '0' && first.Length != 1 || int.Parse(first) > 255)
            {
                continue;
            }

            for (var j = 1; j <= 3 && i + j < s.Length; j++)
            {
                var second = s.Substring(i, j);
                if (second[0] == '0' && second.Length != 1 || int.Parse(second) > 255)
                {
                    continue;
                }

                for (var k = 1; k <= 3  && i + j + k < s.Length; k++)
                {
                    var third = s.Substring(i + j, k);
                    if (third[0] == '0' && third.Length != 1 || int.Parse(third) > 255)
                    {
                        continue;
                    }
                    
                    var fourth = s.Substring(i + j + k);
                    if (fourth[0] == '0' && fourth.Length != 1|| int.Parse(fourth) > 255)
                    {
                        continue;
                    }

                    result.Add(String.Format("{0}.{1}.{2}.{3}", first, second, third, fourth));
                }
            }
        }

        return result;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(", ", new Solution().RestoreIpAddresses("25525511135")));
        Console.WriteLine(String.Join(", ", new Solution().RestoreIpAddresses("0000")));
        Console.WriteLine(String.Join(", ", new Solution().RestoreIpAddresses("1111")));
    }
}
