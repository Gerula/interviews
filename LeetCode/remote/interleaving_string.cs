using System;

class Program {
    public static bool IsInterleave(String s1, String s2, String s3) {
        return Interleave(s1, 0, s2, 0, s3, 0);
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
