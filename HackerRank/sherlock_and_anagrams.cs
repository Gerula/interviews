//  https://www.hackerrank.com/challenges/sherlock-and-anagrams
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static int NumPairs(String s) {
        var count = 0;
        for (var i = 1; i < s.Length; i++) {
            var pairs = new List<String>();
            for (var j = 0; j < s.Length - i + 1; j++) {
                pairs.Add(s.Substring(j, i));
            }
            
            for (var first = 1; first < pairs.Count; first++) {
                for (var second = 0; second < first; second++) {
                    if (IsAnagram(pairs[first], pairs[second])) {
                        count++;
                    }
                }
            }
        }
        
        return count;
    }
    
    static bool IsAnagram(String a, String b) {
        return a.OrderBy(x => x).SequenceEqual(b.OrderBy(x => x));
    }
    
    /* 
        i f a i l u h k q q
        i - i (1, 1), (4, 4)
        q - q (9, 9), (10, 10)
        ifa - fai (1, 3), (2, 4)
    */
    static void Main(String[] args) {
        var count = int.Parse(Console.ReadLine());
        for (var i = 0; i < count; i++) {
            Console.WriteLine(NumPairs(Console.ReadLine()));
        }
    }
}
