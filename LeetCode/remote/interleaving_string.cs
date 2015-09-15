using System;

class Program {
    public static bool IsInterleave(String s1, String s2, String s3) {
        int n = s1.Length;
        bool[,] dp = new bool[n + 1, n + 1];
        
        for (int i = 0; i < n; i++) {
            dp[i, 0] = true;
            dp[0, i] = true;
        }

        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= n; j++) {
                dp[i, j] = (s1[i - 1] == s3[i + j - 1] || s2[j - 1] == s3[i + j - 1]) && (dp[i - 1, j] || dp[i, j - 1]);
            }
        }

        return dp[n, n];
    }

    public static bool Interleave(String s1, int i1, String s2, int i2, String s3, int i3) {
        if (i3 == s3.Length) {
            return i1 == s1.Length && i2 == s2.Length;
        }

        bool left = false;
        if (i1 < s1.Length && s1[i1] == s3[i3]) {
            left = Interleave(s1, i1 + 1, s2, i2, s3, i3 + 1);
        }

        bool right = false;
        if (i2 < s2.Length && s2[i2] == s3[i3]) {
            right = Interleave(s1, i1, s2, i2 + 1, s3, i3 + 1);
        }
        
        return left || right;
    }

    static void Main() {
        String s1 = "aabcc";
        String s2 = "dbbca";
        String s3 = "aadbbcbcac";
        Console.WriteLine("S1:{0}, S2:{1}, S3:{2}, Expected:{3}, Actual:{4}", s1, s2, s3, true, IsInterleave(s1, s2, s3));    
        s3 = "aadbbbaccc";
        Console.WriteLine("S1:{0}, S2:{1}, S3:{2}, Expected:{3}, Actual:{4}", s1, s2, s3, false, IsInterleave(s1, s2, s3));    
    }
}
