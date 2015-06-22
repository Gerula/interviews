using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static string lswrc(string s) {
        if (String.IsNullOrEmpty(s)) {
            return String.Empty;
        }

        Dictionary<char, int> hash = new Dictionary<char, int>(); 
        int max_left = 0;
        int max_right = 0;
        int left = 0;
        int right = 0;
        for (int i = 0; i < s.Length; i++) {
            char c = s[i];
            right = i;
            int leftAux;
            while (hash.TryGetValue(c, out leftAux) && left < i)
            {
                left = leftAux + 1;
                c = s[left];
            }

            hash[c] = i;
            if (right - left > max_right - max_left) {
                max_right = right;
                max_left = left;
            }
        }

        return s.Substring(max_left, max_right - max_left + 1);
    }

    static void Main() {
        new List<string> {"abcabcbb", "bbbbb", "", "abba"}.ForEach( x => Console.WriteLine("{0} - {1}", x, lswrc(x)));
    }
}
