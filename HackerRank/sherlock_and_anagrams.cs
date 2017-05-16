//  https://www.hackerrank.com/challenges/sherlock-and-anagrams
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static int NumPairs(String s) {
        var count = 0;
        for (var i = 1; i < s.Length; i++) {
            var hash = new Dictionary<String, int>();
            for (var j = 0; j < s.Length - i + 1; j++) {
                var substring = Hash(s.Substring(j, i));
                if (!hash.ContainsKey(substring)) {
                    hash[substring] = 0;
                }
                
                hash[substring]++;
            }
            
            count += hash.Keys.Select(x => hash[x] < 2 ? 0 : hash[x] * (hash[x] - 1) / 2).Sum();
        }
        
        return count;
    }
    
    static String Hash(String s) {
        var hash = s.Aggregate(
            new Dictionary<char, int>(),
            (acc, x) => {
                if (!acc.ContainsKey(x)) {
                    acc[x] = 0;
                } 
                
                acc[x]++;
                return acc;
            });
        
        return String
               .Join(
                  String.Empty,
                  Enumerable.Range('a', 'z' - 'a' + 1)
                  .Select(
                      x => hash.ContainsKey((char) x) ? 
                      String.Format("{0}:{1}", (char) x, hash[(char) x]) :
                      String.Empty));
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
