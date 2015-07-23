// https://leetcode.com/submissions/detail/33897217/ 

public class Solution {
    public IList<string> Anagrams(string[] strs) {
        Dictionary<String, List<String>> result = new Dictionary<String, List<String>>();
        foreach (string s in strs) {
            string sorted = String.Join("", s.OrderBy(x => x));
            if (result.ContainsKey(sorted)) {
                result[sorted].Add(s);
            } else {
                result[sorted] = new List<String>() {s};
            }
        }
        
        return result.Values.Where(x => x.Count > 1).SelectMany(x => x).ToList();
    }
}
