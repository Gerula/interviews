//  https://leetcode.com/problems/longest-common-prefix/
//  Write a function to find the longest common prefix string amongst an array of strings. 
//  Strugglish.. Some Ruby shit like lowercase function rubbed off.
//  https://leetcode.com/submissions/detail/55171731/
//
//  Submission Details
//  117 / 117 test cases passed.
//      Status: Accepted
//      Runtime: 184 ms
//          
//          Submitted: 0 minutes ago
public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        if (!strs.Any())
        {
            return String.Empty;
        }
        
        return strs
               .Aggregate((acc, x) => {
                    return String.Join(String.Empty, acc
                                                     .Zip(x, (a, b) => new { First = a, Second = b })
                                                     .TakeWhile(y => y.First == y.Second)
                                                     .Select(y => y.First));       
               });
    }
}
