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
    static ulong HashBase = 27;
    static IEnumerable<String> OneEdit(this String[] a, String s)
    {
        var hash = s.Hash();
        return a
               .Select(x => new { Diff = hash - x.Hash(), String = x })
               .Where(x => x.Diff != 0 && (x.Diff.PowerOf(HashBase)))
               .Select(x => x.String);
    }

    static bool PowerOf(this ulong x, ulong hashBase)
    {
        while (x % hashBase == 0)
        {
            x /= hashBase;
        }

        return x < hashBase;
    }

    static ulong Hash(this String s)
    {
        return s.Aggregate((ulong) 0, (acc, x) => acc * HashBase + x - 'a');
    }

    static void Main()
    {
        Console.WriteLine(String.Join(
                    ", ", 
                    new [] {"bana", "banan", "abanana", "anana", "apple", "banaba", "bonanza", "banamf", "banana" }
                    .OneEdit("banana")));
    }
}
