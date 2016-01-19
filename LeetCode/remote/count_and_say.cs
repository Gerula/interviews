//  https://leetcode.com/problems/count-and-say/
//
//  The count-and-say sequence is the sequence of integers beginning as follows:
//  1, 11, 21, 1211, 111221, ...
//
//  1 is read off as "one 1" or 11.
//  11 is read off as "two 1s" or 21.
//  21 is read off as "one 2, then one 1" or 1211.
//
//  Given an integer n, generate the nth sequence.
//
//  Note: The sequence of integers will be represented as a string. 

using System.Text.RegularExpressions;

public class Solution {
    //  
    //  Submission Details
    //  18 / 18 test cases passed.
    //      Status: Accepted
    //      Runtime: 120 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  You are here!
    //  Your runtime beats 1.70% of csharp submissions. Hueheuehehue
    public string CountAndSay(int n) {
        var r = new Regex(@"(.)\1*");
        var start = "1";
        for (var i = 1; i < n; i++)
        {
            start = CountAndSay(start, r);
        }
        
        return start;
    }
    
    public string CountAndSay(string s, Regex r)
    {
        return r.Replace(s, x => String.Format("{0}{1}", x.Length, x.Value[0]));
    }
}
