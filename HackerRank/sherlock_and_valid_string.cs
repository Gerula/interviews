//  https://www.hackerrank.com/challenges/sherlock-and-valid-string
//  15 out of 16 pass
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static bool Valid(String s) {
        var groups = s.Aggregate(
                        new Dictionary<char, int>(),
                        (acc, x) => {
                            if (!acc.ContainsKey(x)) {
                                acc[x] = 0;
                            }

                            acc[x]++;
                            return acc;
                        })
                      .GroupBy(x => x.Value)
                      .ToArray();
        
        return groups.Length == 1 || 
               groups.Length == 2 && 
                        (Math.Abs(groups[0].Count() - groups[1].Count()) == 1 || 
                         groups[0].Count() == 1 ||
                         groups[1].Count() == 1);
    }
    
    static void Main(String[] args) {
        Console.WriteLine(Valid(Console.ReadLine()) ? "YES" : "NO");
    }
}
