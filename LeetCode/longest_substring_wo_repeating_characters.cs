using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program {
    static string lswrc(string s) {
        if (String.IsNullOrEmpty(s)) {
            return String.Empty;
        }

        BitArray exists = new BitArray(255);
        int i = 0;
        int j = 0;
        int max = 0;

        while (j < s.Length) {
            if (exists[s[j]]) {
                max = Math.Max(max, j - i);
                while (s[i] != s[j]) {
                    exists[s[i]] = false;
                    i++;
                }
                i++;
                j++;
            } else {
                exists[s[j]] = true;
                j++;
            }
        }

        max = Math.Max(max, s.Length - i);
        return max.ToString();
    }

    static void Main() {
        new List<string> {"abcabcbb", "bbbbb", "", "abba"}.ForEach( x => Console.WriteLine("{0} - {1}", x, lswrc(x)));
    }
}
