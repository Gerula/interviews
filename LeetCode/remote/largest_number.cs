//  https://leetcode.com/problems/largest-number/
//
//  Given a list of non negative integers, arrange them such that they form the largest number.
//
//  For example, given [3, 30, 34, 5, 9], the largest formed number is 9534330.
//
//  Note: The result may be very large, so you need to return a string instead of an integer.

public class Solution {
    //  
    //  Submission Details
    //  221 / 221 test cases passed.
    //      Status: Accepted
    //      Runtime: 184 ms
    //          
    //          Submitted: 1 minute ago
    //
    //  https://leetcode.com/submissions/detail/52759669/
    //
    //  You are here!
    //  Your runtime beats 84.09% of csharp submissions.
    public string LargestNumber(int[] nums) {
        var strings = nums.Select(x => x.ToString()).ToArray();
        if (strings.All(x => x == "0"))
        {
            return "0";
        }
        
        Array.Sort(strings, (a, b) => -(a + b).CompareTo(b + a));
        return String.Join("", strings);
    }
}

//  https://leetcode.com/submissions/detail/58177018/
//
//  Submission Details
//  221 / 221 test cases passed.
//      Status: Accepted
//      Runtime: 240 ms
//          
//          Submitted: 0 minutes ago
//
using System.Text.RegularExpressions;

public class Solution {
    public class NumComparer : IComparer<String>
    {
        public int Compare(String a, String b)
        {
            return (b + a).CompareTo(a + b);
        }
    }
    
    public string LargestNumber(int[] nums) {
        return Regex.Replace(String.Join(
            String.Empty,
            nums
            .Select(x => x.ToString())
            .OrderBy(a => a, new NumComparer())),
            "^0+", "0"
            );
    }
}
