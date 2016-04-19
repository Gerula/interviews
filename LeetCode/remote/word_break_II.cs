//  https://leetcode.com/problems/word-break-ii/
//   Given a string s and a dictionary of words dict,
//   add spaces in s to construct a sentence where each word is a valid dictionary word.
//
//   Return all such possible sentences. 
//
//   https://leetcode.com/submissions/detail/59418381/
//
//   Submission Details
//   37 / 37 test cases passed.
//      Status: Accepted
//      Runtime: 632 ms
//          
//          Submitted: 0 minutes ago
public class Solution {
    public IList<string> WordBreak(string s, ISet<string> wordDict, Dictionary<String, IList<string>> cache = null) 
    {
        if (String.IsNullOrWhiteSpace(s))
        {
            return new List<string> { "" };
        }
        
        if (cache == null)
        {
            cache = new Dictionary<String, IList<string>>();
        }
        
        if (cache.ContainsKey(s))
        {
            return cache[s];
        }
        
        cache[s] = wordDict
                   .Where(x => s.StartsWith(x))
                   .SelectMany(
                       x => WordBreak(s.Substring(x.Length), wordDict, cache),
                       (a, b) => String.Format("{0} {1}", a, b).Trim())
                   .ToList();
        return cache[s];
    }
}
