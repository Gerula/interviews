// https://leetcode.com/problems/valid-parentheses/

public class Solution {
    public bool IsValid(string s) {
        string prev = s;

        while (!String.IsNullOrWhiteSpace(s)) {
            s = s.Replace("()", String.Empty).
                Replace("[]", String.Empty).
                Replace("{}", String.Empty);
            if (s == prev) {
                return false;
            }
            prev = s;
        }

        return true;
    }
}
