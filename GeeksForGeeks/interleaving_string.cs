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

    static void Main()
    {
        foreach (var x in new [] {
                    Tuple.Create("aadbbcbcac","aabcc","dbbca", true),
                    Tuple.Create("aadbbbaccc","aabcc","dbbca", false)
                })
        {
            Console.WriteLine("{0} {1} {2}", x.Item1, x.Item1.Inter(x.Item2, x.Item3), x.Item4);
        }
    }
}
