//  https://leetcode.com/submissions/detail/49105405/

public class Solution {
    public bool IsMatch(string s, string p)
    {
        var dp = new bool[s.Length + 1, p.Length + 1];
        dp[s.Length, p.Length] = true;
        for (var i = p.Length - 1; i >= 0; i--)
        {
            if (p[i] != '*')
            {
                break;
            }

            dp[s.Length, i] = true;
        }

        for (var i = s.Length - 1; i >= 0; i--)
        {
            for (var j = p.Length - 1; j >= 0; j--)
            {
                if (s[i] == p[j] || p[j] == '?')
                {
                    dp[i, j] = dp[i + 1, j + 1];
                }
                else if (p[j] == '*')
                {
                    dp[i, j] = dp[i + 1, j] || dp[i, j + 1];
                }
            }
        }

        return dp[0, 0];
    }
}
