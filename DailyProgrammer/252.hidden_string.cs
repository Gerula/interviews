//  https://www.reddit.com/r/dailyprogrammer/comments/442mec/20160203_challenge_252_intermediate_a_challenge/
//
//  For the following 3200 character string (ignoring newlines): (...)
//  1.  Find the pair of identical characters that are farthest apart,
//      and contain no pairs of identical characters between them.
//      (e.g. for "abcbba" the chosen characters should be the first and last "b")
//      
//      a b c b d b a
//
//      In the event of a tie, choose the left-most pair.
//      (e.g. for "aabcbded" the chosen characters should be the first and second "b")
//
//  2.  Remove one of the characters in the pair, and move the other to the end of the string.
//      (e.g. for "abcbba" you'd end up with "acbab")
//
//  3.  Repeat steps 1 and 2 until no repeated characters remain.
//
//  4.  If the resulting string contains an underscore,
//      remove it and any characters after it. (e.g. "abc_def" would become "abc")
//
//  5.  The remaining string is the answer.

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

static class Solution
{
    static String Hidden(this String s)
    {
        Console.WriteLine(s.Length);
        var sb = new StringBuilder(s);
        Tuple<int, int> indexes;
        while ((indexes = Farthest(sb)) != null)
        {
            var c = sb[indexes.Item1];
            sb.Remove(indexes.Item1, 1);
            sb.Remove(indexes.Item2 - 1, 1);
            sb.Append(c);
        }

        var result = sb.ToString();
        Console.WriteLine(result);
        if (result.Contains("_"))
        {
            return result.Substring(0, result.IndexOf("_"));
        }

        return result;
    }

    static Tuple<int, int> Farthest(this StringBuilder sb)
    {
        var hashSet = new HashSet<char>();
        var counts = new Dictionary<char, int>();
        var left = 0;
        var maxLeft = 0;
        var maxRight = 0;
        for (var i = 0; i < sb.Length; i++)
        {
            if (!hashSet.Contains(sb[i]))
            {
                hashSet.Add(sb[i]);
                counts[sb[i]] = 1;
            }
            else
            {
                counts[sb[i]]++;
                while (sb[left] != sb[i])
                {
                    hashSet.Remove(sb[left++]);
                }

                if (left == i)
                {
                    hashSet.Remove(sb[i]);
                }
                
                if (i - left > maxRight - maxLeft)
                {
                    maxRight = i;
                    maxLeft = left;
                }
            }
        }

        return maxLeft + maxRight == 0 ? null : Tuple.Create(maxLeft, maxRight);
    }

    static void Main()
    {
        Console.WriteLine("abcbba".Hidden());
        Console.WriteLine("abcdfbeba".Hidden());
        Console.WriteLine("aabcbded".Hidden());
        Console.WriteLine("daccadfghd_i".Hidden());
        Console.WriteLine("abacbcbefge".Hidden());
        Console.WriteLine("_a_abda_".Hidden());
        Console.WriteLine("ttvmswxjzdgzqxotby_lslonwqaipchgqdo_yz_fqdagixyrobdjtnl_jqzpptzfcdcjjcpjjnnvopmh".Hidden());
        Console.WriteLine(File
                          .ReadAllText("252.in")
                          .Replace(Environment.NewLine, String.Empty)
                          .ToUpper()
                          .Hidden());
    }
}
