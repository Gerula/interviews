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

//  Poor man's DP but still TLE
public class Solution {
    public bool IsMatch(string s, string p, bool[,] hash = null) {
        if (hash == null)
        {
            hash = new bool[s.Length + 1, p.Length + 1];
        }
        
        if (String.IsNullOrWhiteSpace(s))
        {
            hash[s.Length, p.Length] = String.IsNullOrWhiteSpace(p) || p == "*";
            return hash[s.Length, p.Length];
        }
        
        if (String.IsNullOrWhiteSpace(p))
        {
            hash[s.Length, p.Length] = p == s;
            return hash[s.Length, p.Length];
        }
        
        if (p[0] == '?' || s[0] == p[0])
        {
            hash[s.Length, p.Length] = IsMatch(s.Substring(1), p.Substring(1), hash);
            return hash[s.Length, p.Length];
        }
        
        if (p[0] == '*')
        {
            hash[s.Length, p.Length] = Enumerable
                                       .Range(0, s.Length)
                                       .Select(x => IsMatch(s.Substring(x), p.Substring(1)))
                                       .Aggregate((acc, x) => acc || x);
            return hash[s.Length, p.Length];
        }
    
        hash[s.Length, p.Length] = false;
        return hash[s.Length, p.Length];
    }
}
