//  https://leetcode.com/problems/find-all-anagrams-in-a-string/
//
//  Memory limit exceeded my ass..

public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
        if (s.Length < p.Length) {
            return Enumerable.Empty<int>().ToList();
        }

        var hash = p.Aggregate(0, (acc, x) => acc ^ x);
        var inputHash = s.Take(p.Length).Aggregate(0, (acc, x) => acc ^ x);
        var result = new List<int>();
        if (inputHash == hash && EqualAnyOrder(s.Substring(0, p.Length), p)) {
            result.Add(0);
        }

        for (var i = p.Length; i < s.Length; i++) {
            inputHash ^= s[i];
            inputHash ^= s[i - p.Length];
            if (inputHash == hash && EqualAnyOrder(s.Substring(i - p.Length + 1, p.Length), p)) {
                result.Add(i - p.Length + 1);
            }
        }

        return result;
    }
    
    public bool EqualAnyOrder(String s, String p) {
        var map = new int[27];
        foreach (var x in s) {
            map[x - 'a']++;
        }

        foreach (var x in p) {
            map[x - 'a']--;
            if (map[x - 'a'] < 0) {
                return false;
            }
        }

        return map.All(x => x == 0);
    }
}
