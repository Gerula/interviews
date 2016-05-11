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

    //  
    //  Submission Details
    //  30 / 30 test cases passed.
    //      Status: Accepted
    //      Runtime: 476 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  https://leetcode.com/submissions/detail/50986443/
    //
    //  You are here!
    //  Your runtime beats 100.00% of csharp submissions.
    //
    //  Fuckin' A!!
    public IList<string> FindRepeatedDnaSequencesFast(string s) {
        var set = new HashSet<String>();
        var seen = new HashSet<long>();
        var map = new Dictionary<char, int> { { 'A', 1 }, { 'C', 2 }, { 'G', 3 }, { 'T', 4 } };
        long window = 0;
        long pow = (long) Math.Pow(10, 9);

        for (var i = 0; i < s.Length; i++)
        {
            if (i > 9)
            {
                window %= pow;
            }

            window = (long) (window * 10 + map[s[i]]);
            
            if (seen.Contains(window))
            {
                set.Add(s.Substring(i - 9, 10));
            }
            else 
            {
                seen.Add(window);
            }
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

    //  Not TLE but shittier than the above :(
    //  https://leetcode.com/submissions/detail/61269132/
    //
    //  Submission Details
    //  30 / 30 test cases passed.
    //      Status: Accepted
    //      Runtime: 592 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public IList<string> FindRepeatedDnaSequences(string s) {
        const int length = 10;
        if (s.Length < length)
        {
            return new List<string>();    
        }
        
        return Enumerable
               .Range(0, s.Length - length + 1)
               .Aggregate(
                   new Dictionary<String, int>(),
                   (acc, x) => {
                       var sequence = s.Substring(x, length);
                       if (!acc.ContainsKey(sequence))
                       {
                           acc[sequence] = 0;
                       }
                       
                       acc[sequence]++;
                       return acc;
                   })
               .Where(x => x.Value > 1)
               .Select(x => x.Key)
               .ToList();
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, new Solution().FindRepeatedDnaSequences("AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT")));
        Console.WriteLine(String.Join(Environment.NewLine, new Solution().FindRepeatedDnaSequences("CGACGCAATTTAGAACGGGCCGCACTGCAACCATTGCTCAGACAACGCATGAGTTAAATTTCACAAGTGATAGTGGCTTGCGAGACGTGGGTTGGTGGTAGCGTACGCCCGCTATTCGCCCCTAACGTGACGGGATTATAAGGTCGCTTCCCGGAATGCGCAGACGAGTCTCCGGTTTAGCCTAGACGTCTCACGCGCGCAAGGCGTCAGTTCTCACTATCTCGCACAGGTGTATTCTATTAGTTATGGGTTCTCACTACAGTCGGTTACTTCCTCATCCATTTCTGCATACGGGTCAACTAACAGTGTCATGGGGTATTGGGAAGGATGCGTTTTTAAACCCTCTCAGTAGCGCGAGGATGCCCACAAATACGACGGCGGCCACGGATCTAATGCGAAGCTAGCGACGCTTTCCAGCAACGAGCGCCCCACTTATGACTGCGTGGGGCGCTCCGCTTTCCTAGAGAACATAGATGGTGTTTTCGAATCGTAACCACTTA")));
        Console.WriteLine();
        Console.WriteLine(String.Join(Environment.NewLine, new Solution().FindRepeatedDnaSequencesFast("AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT")));
        Console.WriteLine(String.Join(Environment.NewLine, new Solution().FindRepeatedDnaSequencesFast("CGACGCAATTTAGAACGGGCCGCACTGCAACCATTGCTCAGACAACGCATGAGTTAAATTTCACAAGTGATAGTGGCTTGCGAGACGTGGGTTGGTGGTAGCGTACGCCCGCTATTCGCCCCTAACGTGACGGGATTATAAGGTCGCTTCCCGGAATGCGCAGACGAGTCTCCGGTTTAGCCTAGACGTCTCACGCGCGCAAGGCGTCAGTTCTCACTATCTCGCACAGGTGTATTCTATTAGTTATGGGTTCTCACTACAGTCGGTTACTTCCTCATCCATTTCTGCATACGGGTCAACTAACAGTGTCATGGGGTATTGGGAAGGATGCGTTTTTAAACCCTCTCAGTAGCGCGAGGATGCCCACAAATACGACGGCGGCCACGGATCTAATGCGAAGCTAGCGACGCTTTCCAGCAACGAGCGCCCCACTTATGACTGCGTGGGGCGCTCCGCTTTCCTAGAGAACATAGATGGTGTTTTCGAATCGTAACCACTTA")));
        Console.WriteLine();
        Console.WriteLine(String.Join(Environment.NewLine, new Solution().FindRepeatedDnaSequences2("AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT")));
        Console.WriteLine(String.Join(Environment.NewLine, new Solution().FindRepeatedDnaSequences2("CGACGCAATTTAGAACGGGCCGCACTGCAACCATTGCTCAGACAACGCATGAGTTAAATTTCACAAGTGATAGTGGCTTGCGAGACGTGGGTTGGTGGTAGCGTACGCCCGCTATTCGCCCCTAACGTGACGGGATTATAAGGTCGCTTCCCGGAATGCGCAGACGAGTCTCCGGTTTAGCCTAGACGTCTCACGCGCGCAAGGCGTCAGTTCTCACTATCTCGCACAGGTGTATTCTATTAGTTATGGGTTCTCACTACAGTCGGTTACTTCCTCATCCATTTCTGCATACGGGTCAACTAACAGTGTCATGGGGTATTGGGAAGGATGCGTTTTTAAACCCTCTCAGTAGCGCGAGGATGCCCACAAATACGACGGCGGCCACGGATCTAATGCGAAGCTAGCGACGCTTTCCAGCAACGAGCGCCCCACTTATGACTGCGTGGGGCGCTCCGCTTTCCTAGAGAACATAGATGGTGTTTTCGAATCGTAACCACTTA")));
    }
}


