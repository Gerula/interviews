//  https://leetcode.com/problems/repeated-dna-sequences/
//
//   All DNA is composed of a series of nucleotides abbreviated as A, C, G, and T, for example: "ACGAATTCCG".
//   When studying DNA, it is sometimes useful to identify repeated sequences within the DNA.
//
//   Write a function to find all the 10-letter-long sequences (substrings) that occur more than once in a DNA molecule.

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public IList<string> FindRepeatedDnaSequences(string s) {
        var set = new HashSet<String>();
        for (var i = 0; i < s.Length - 10; i++)
        {
            var seq = s.Substring(i, 10);
            if (set.Contains(seq))
            {
                continue;
            }

            if (s.Substring(i + 10).Contains(seq))
            {
                set.Add(seq);
            }
        }

        return set.ToList();
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, new Solution().FindRepeatedDnaSequences("AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT")));
    }
}
