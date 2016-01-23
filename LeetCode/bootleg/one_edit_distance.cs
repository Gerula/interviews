//  http://lcoj.tk/problems/one-edit-distance-ii-dietpepsi-in_progress/
//
//   Given string s and a string array targets, determine if there is a string in the array that is one edit distance apart from s.
//
//   Example:
//
//   Given
//   s = "banana"
//   targets = ["bana", "apple", "banaba", "bonanza", "banamf"]
//   Return true
//   "banaba" is one edit distance apart from "banana" 

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static long HashBase = 27;
    static IEnumerable<String> OneEdit(this String[] a, String s)
    {
        var hash = s.Hash();
        return a
               .Select(x => new { Diff = Math.Abs(x.Hash() - hash), String = x })
               .Where(x => x.Diff != 0 && x.Diff.PowerOf(HashBase) && x.String.OneEdit(s))
               .Select(x => x.String);
    }

    static bool OneEdit(this String a, String b)
    {
        if (Math.Abs(a.Length - b.Length) > 1)
        {
            return false;
        }

        var i = 0;
        var j = 0;
        var diff = 0;
        while (i < a.Length && j < b.Length)
        {
            if (a[i] != b[j])
            {
                if (++diff > 1)
                {
                    return false;
                }

                if (a.Length < b.Length)
                {
                    j++;
                    continue;
                }
                else if (a.Length > b.Length)
                {
                    i++;
                    continue;
                }
            }

            i++; j++;
        }

        return true;
    }

    static bool PowerOf(this long x, long hashBase)
    {
        while (x % hashBase == 0)
        {
            x /= hashBase;
        }

        return x < hashBase;
    }

    static long Hash(this String s)
    {
        return s.Aggregate((long) 0, (acc, x) => acc * HashBase + x - 'a' + 1);
    }

    static void Main()
    {
        Console.WriteLine(String.Join(
                    ", ", 
                    new [] {"bana", "banan", "abanana", "anana", "apple", "banaba", "bonanza", "banamf", "banana" }
                    .OneEdit("banana")));
    }
}
