//  https://leetcode.com/problems/sort-characters-by-frequency/
//  https://leetcode.com/submissions/detail/83684155/
//
//  Submission Details
//  34 / 34 test cases passed.
//      Status: Accepted
//      Runtime: 188 ms
//          Submitted: 0 minutes ago

public class Solution {
    public string FrequencySort(string s) {
        return s.Aggregate(new Dictionary<char, int>(), (acc, x) => {
            if (!acc.ContainsKey(x)) {
                acc[x] = 0;
            }

            acc[x]++;
            return acc;
        })
        .OrderByDescending(x => x.Value)
        .Aggregate(new StringBuilder(), (acc, x) => {
            acc.Append(new String(x.Key, x.Value));
            return acc;
        })
        .ToString();
    }
}
