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
    //  https://leetcode.com/submissions/detail/50962169/
    //
    //
    //  Submission Details
    //  30 / 30 test cases passed.
    //      Status: Accepted
    //      Runtime: 568 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public IList<string> FindRepeatedDnaSequences(string s) {
        var set = new HashSet<String>();
        var seen = new HashSet<String>();
        for (var i = 0; i < s.Length - 9; i++)
        {
            var seq = s.Substring(i, 10);
            if (seen.Contains(seq))
            {
                set.Add(seq);
            }
            
            seen.Add(seq);
        }

        return set.ToList();
    }

    //  Same idea but with linq. TLE
    public IList<string> FindRepeatedDnaSequences2(string s) {
        return Enumerable
               .Range(0, s.Length - 9)
               .Select(x => s.Substring(x, 10))
               .GroupBy(x => x)
               .Where(x => x.Count() > 1)
               .Select(x => x.Key)
               .ToList();
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, new Solution().FindRepeatedDnaSequences("AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT")));
        Console.WriteLine(String.Join(Environment.NewLine, new Solution().FindRepeatedDnaSequences2("AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT")));
    }
}
