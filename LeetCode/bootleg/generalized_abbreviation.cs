//  http://lcoj.tk/problems/generalized-abbreviationleetzeky-for-review/
//
//  Given an Generalized abbreviation function:
//  for example for the word "word" f(word) would return a list of string:
//  ["word", "1ord", "w1rd", "wo1d", "wor1", "2rd", "w2d", "wo2", "1o1d", "1or1", "w1r1", "1o2", "2r1", "3d", "w3", "4"]

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

static class Program
{
    static IEnumerable<String> Abbreviations(this String s)
    {
        switch (s.Length)
        {
            case 0: 
                return Enumerable.Empty<String>();
            case 1:
                return new List<String> { s };
            case 2:
                return new List<String> { s, String.Format("{0}{1}", s[0], 1) };
            default:
                return Enumerable
                       .Range(1, s.Length - 2)
                       .SelectMany(x => s
                                        .Substring(x + 1)
                                        .Abbreviations()
                                        .Select(y => x.ToString() + s[x] + y))
                       .Concat(s
                               .Substring(1)
                               .Abbreviations()
                               .Select(x => s[0] + x))
                       .Concat(new List<String> { s.Length.ToString() });
        }
    }

    static IEnumerable<String> Abbreviations2(this String s)
    {
        var regex = new Regex(@"\#+");
        for (var mask = 0; mask < 1 << s.Length; mask++)
        {
            var sb = new StringBuilder(s);
            for (var i = 0; i < s.Length; i++)
            {
                if ((mask & (1 << i)) != 0)
                {
                    sb[i] = '#';
                }
            }

            yield return regex.Replace(sb.ToString(), x => x.Length.ToString());
        }
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, "word".Abbreviations()));
        Console.WriteLine();
        Console.WriteLine(String.Join(Environment.NewLine, "generic".Abbreviations()));
        Console.WriteLine();
    }
}
