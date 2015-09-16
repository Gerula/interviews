// 
// Submission Details
// 101 / 101 test cases passed.
//  Status: Accepted
//  Runtime: 136 ms
//      
//      Submitted: 0 minutes ago
// 
// Sometimes all you need is something to knock you down from your high horse
// and fall right on your ass. This time it was the Leetcode test cases and it
// feels surprinsingly good.
//
// So first I assumed (ass == u and me) that s1 and s2 need to have the same 
// length and afterwards I forgot to hunt down the edge cases. This is what happens
// when you forget your place.

using System;

class Program {
    public static bool IsInterleave(String s1, String s2, String s3) {
        int n = s1.Length;
        int m = s2.Length;
        bool[,] dp = new bool[n + 1, m + 1];
        
        if (s1.Length + s2.Length != s3.Length) {
            return false;
        }
        
        dp[0, 0] = true;

        for (int i = 1; i <= n; i++) {
            dp[i, 0] = s1[i - 1] == s3[i - 1] && dp[i - 1, 0];
        }

        for (int j = 1; j <= m; j++) {
            dp[0, j] = s2[j - 1] == s3[j - 1] && dp[0, j - 1];
        }

        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= m; j++) {
                dp[i, j] = s1[i - 1] == s3[i + j - 1] && dp[i - 1, j] || 
                           s2[j - 1] == s3[i + j - 1] && dp[i, j - 1];
            }
        }
        
        return dp[n, m]; 
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
        Console.WriteLine("S1:{0}, S2:{1}, S3:{2}, {3}", s1, s2, s3,  IsInterleave(s1, s2, s3) ? "Ok" : "/\\");    
        s3 = "aadbbbaccc";
        Console.WriteLine("S1:{0}, S2:{1}, S3:{2}, {3}", s1, s2, s3, !IsInterleave(s1, s2, s3) ? "OK" : "/\\");    
        s1 = "a"; s2 = ""; s3 = "a";
        Console.WriteLine("S1:{0}, S2:{1}, S3:{2}, {3}", s1, s2, s3, IsInterleave(s1, s2, s3) ? "OK" : "/\\");    
        s1 = "a"; s2 = ""; s3 = "c";
        Console.WriteLine("S1:{0}, S2:{1}, S3:{2}, {3}", s1, s2, s3, !IsInterleave(s1, s2, s3) ? "OK" : "/\\");    
        s1 = ""; s2 = ""; s3 = "";
        Console.WriteLine("S1:{0}, S2:{1}, S3:{2}, {3}", s1, s2, s3, IsInterleave(s1, s2, s3) ? "OK" : "/\\");    
        s1 = "abc"; s2 = ""; s3 = "";
        Console.WriteLine("S1:{0}, S2:{1}, S3:{2}, {3}", s1, s2, s3, !IsInterleave(s1, s2, s3) ? "OK" : "/\\");    
        s1 = "ab"; s2 = "bc"; s3 = "bbac";
        Console.WriteLine("S1:{0}, S2:{1}, S3:{2}, {3}", s1, s2, s3, !IsInterleave(s1, s2, s3) ? "OK" : "/\\");    
    }
}
