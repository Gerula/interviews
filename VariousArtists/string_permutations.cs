// Given a string, collect all permutations
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

static class Program
{
    static List<String> Permute(this String s)
    {
        var result = new List<String>();
        Permutations(new StringBuilder(s), 0, result);
        return result;
    }

    static void Permutations(StringBuilder s, int start, List<String> results)
    {
        if (start == s.Length)
        {
            results.Add(s.ToString());
            return;
        }

        for (var i = start; i < s.Length; i++)
        {
            s.Swap(start, i);
            Permutations(s, start + 1, results);
            s.Swap(start, i);
        }
    }

    static void Swap(this StringBuilder s, int a, int b)
    {
        var c = s[a];
        s[a] = s[b];
        s[b] = c;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, "gerula".Permute()));
        Console.WriteLine(String.Join(Environment.NewLine, "abc".Permute()));
    }
}
