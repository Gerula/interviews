using System;
using System.Text;

static class Program {
    static String Reverse(this String s) {
        StringBuilder sb = new StringBuilder(s);
        sb.Reverse(0, s.Length - 1);
        int start = 0;
        for (int i = 0; i < sb.Length; i++) {
            if (sb[i] == ' ' || i == sb.Length - 1) {
                sb.Reverse(start, i == sb.Length - 1 ? i : i - 1);
                start = i + 1;
            }
        }

        return sb.ToString();
    }

    static void Reverse(this StringBuilder s, int start, int end) {
        start--; end++;
        while (++start < --end) {
            char c = s[start]; s[start] = s[end]; s[end] = c;
        }
    }

    static void Main() {
        String s = "Did you know Mike frank was involved in this?";
        Console.WriteLine(s);
        Console.WriteLine(s.Reverse());
    }
}

