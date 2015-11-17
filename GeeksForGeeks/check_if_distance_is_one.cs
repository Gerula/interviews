// http://www.geeksforgeeks.org/check-if-two-given-strings-are-at-edit-distance-one/
//
// An edit between two strings is one of the following changes.
//
// Add a character
// Delete a character
// Change a character
//
// Given two string s1 and s2, find if s1 can be converted to s2 with exactly one edit. Expected time complexity is O(m+n) where m and n are lengths of two strings.
//
// Examples:
//
// Input:  s1 = "geeks", s2 = "geek"
// Output: yes
// Number of edits is 1
//
// Input:  s1 = "geeks", s2 = "geeks"
// Output: no
// Number of edits is 0
//
// Input:  s1 = "geaks", s2 = "geeks"
// Output: yes
// Number of edits is 1
//
// Input:  s1 = "peaks", s2 = "geeks"
// Output: no
// Number of edits is 2
//

using System;
using System.Collections.Generic;
using System.Linq;

class DistanceResult
{
    public bool OneDistance { get; set; }
    public String Diff { get; set; }

    public override String ToString()
    {
        return String.Format("[isOne? {0}, diff {1}]", OneDistance, Diff);
    }
}

static class Program
{
    static DistanceResult EditDistance(String s, String p)
    {
        var first = 0;
        var second = 0;
        var edits = 0;
        String diff = String.Empty;

        while (first < s.Length || second < p.Length)
        {
            char? a = first < s.Length ? (char?)s[first] : null;
            char? b = second < p.Length ? (char?)p[second] : null;

            if (a == b)
            {
                first++;
                second++;
                continue;
            }

            edits++;

            if (s.Length == p.Length)
            {
                diff += String.Format("replace {0} with {1} ", a, b);
                first++;
                second++;
                continue;
            }

            if (s.Length < p.Length)
            {
                diff += String.Format("Delete {0} from {1} ", b, p);
                second++;
            }
            else
            {
                diff += String.Format("Delete {0} from {1} ", a, s);
                first++;
            }
        }

        return new DistanceResult { OneDistance = edits == 1, Diff = diff };
    }

    static void Main()
    {
        new [] {
            Tuple.Create("geeks", "geek", true),
            Tuple.Create("geeks", "geeks", false),
            Tuple.Create("geaks", "geeks", true),
            Tuple.Create("peaks", "geeks", false),
        }
        .ToList()
        .ForEach(x => {
                    var result = EditDistance(x.Item1, x.Item2);
                    Console.WriteLine("{0} {1} - {2}", x.Item1, x.Item2, result);
                    if (result.OneDistance != x.Item3)
                    {
                        throw new Exception("U suck");
                    }
                });
    }
}
