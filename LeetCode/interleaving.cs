using System;

class Program {
    static bool IsInterleaved(String s1, String s2, String s3, int i, int j, int k) {
        if (k == s3.Length) {
            return true;
        }

        bool first = i < s1.Length && s1[i] == s3[k] && IsInterleaved(s1, s2, s3, i + 1, j, k + 1);
        bool second = j < s2.Length && s2[j] == s3[k] && IsInterleaved(s1, s2, s3, i, j + 1, k + 1);
        return first || second;
    }

    static void Main() {
        Console.WriteLine(IsInterleaved("aabcc", "dbbca", "aadbbcbcac", 0, 0, 0));
        Console.WriteLine(IsInterleaved("aabcc", "dbbca", "aadbbbaccc", 0, 0, 0));
    }
}
