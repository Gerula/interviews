using System;

static class Program {
    static string LongestPalindrome(this string s) {
        int max_start = 0;
        int max_end = 0;
        for (int i = 0; i < s.Length - 1; i++) {
            int start = i;
            int end = i;
            while (start > 0 && end < s.Length && s[start] == s[end]) {
                start--;
                end++;
            }

            if (end - start > max_end - max_start) {
                max_start = start;
                max_end = end;
            }
            
            start = i;
            end = i + 1;
            while (start > 0 && end < s.Length && s[start] == s[end]) {
                start--;
                end++;
            }

            if (end - start > max_end - max_start) {
                max_start = start;
                max_end = end;
            }
        }

        return s.Substring(max_start, max_end - max_start);
    }

    static void Main() {
        string[] strings = new string[] { "abcdedcb", "abcddcb", "bb" };
        foreach (string s in strings) {
            Console.WriteLine("{0} - {1}", s, s.LongestPalindrome());
        }
    }
}
