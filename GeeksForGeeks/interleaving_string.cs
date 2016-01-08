//  http://www.geeksforgeeks.org/check-whether-a-given-string-is-an-interleaving-of-two-other-given-strings-set-2/
//
//  Given three strings A, B and C.
//  Write a function that checks whether C is an interleaving of A and B.
//  C is said to be interleaving A and B,
//  if it contains all characters of A and B and order of all characters in individual strings is preserved. 

using System;

static class Program
{
    static bool Inter(this String s, String a, String b)
    {
        if (String.IsNullOrEmpty(s))
        {
            return String.IsNullOrEmpty(a) && String.IsNullOrEmpty(b);
        }

        return !String.IsNullOrEmpty(a) && s[0] == a[0] && s.Substring(1).Inter(a.Substring(1), b) ||
               !String.IsNullOrEmpty(b) && s[0] == b[0] && s.Substring(1).Inter(a, b.Substring(1));
    }

    static bool InterDp(this String s, String a, String b)
    {
        var n = a.Length;
        var m = b.Length;
        if (s.Length != n + m)
        {
            return false;
        }

        var interleaved = new bool[n + 1, m + 1];
        interleaved[0, 0] = true;
        for (var i = 1; i <= n && (interleaved[i, 0] = s[i - 1] == a[i - 1] && interleaved[i - 1, 0]); i++) {}
        for (var i = 1; i <= n && (interleaved[0, 0] = s[i - 1] == b[i - 1] && interleaved[0, i - 1]); i++) {}
        for (var i = 1; i <= n; i++)
        {
            for (var j = 1; j <= m; j++)
            {
                interleaved[i, j] = interleaved[i - 1, j] && a[i - 1] == s[i + j - 1] ||
                                    interleaved[i, j - 1] && b[j - 1] == s[i + j - 1];
            }
        }

        return interleaved[n, m];
    }

    static void Main()
    {
        foreach (var x in new [] {
                    Tuple.Create("aadbbcbcac","aabcc","dbbca", true),
                    Tuple.Create("abc","","abc", true),
                    Tuple.Create("aadbbbaccc","aabcc","dbbca", false),
                    Tuple.Create("abc","","ab", false)
                })
        {
            Console.WriteLine("{0} {1} {2}", x.Item1, x.Item1.Inter(x.Item2, x.Item3), x.Item4);
            Console.WriteLine("{0} {1} {2}", x.Item1, x.Item1.InterDp(x.Item2, x.Item3), x.Item4);
        }
    }
}
