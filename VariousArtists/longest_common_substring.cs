//  https://leetcode.com/problems/longest-common-prefix/
//
//  Write a function to find the longest common prefix string amongst an array of strings. 

public class Solution {
    //  
    //  Submission Details
    //  117 / 117 test cases passed.
    //      Status: Accepted
    //      Runtime: 176 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  https://leetcode.com/submissions/detail/52884372/
    public string LongestCommonPrefix(string[] strs) {
        if (!strs.Any())
        {
            return String.Empty;
        }
        
        var min = strs
                  .Select(x => x.Length)
                  .Min();

        if (min == 0)
        {
            return String.Empty;
        }
        
        Console.WriteLine(min);
        for (var i = 0; i < min; i++)
        {
            if (strs.Select(x => x[i]).Distinct().Count() > 1)
            {
                return strs[0].Substring(0, i);
            }
        }
        
        return strs[0].Substring(0, min);
    }
}
