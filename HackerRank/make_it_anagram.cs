//  https://www.hackerrank.com/challenges/make-it-anagram

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static int AnagramCount(String a, String b) {
        var dictionary = a.Aggregate(
            new Dictionary<char, int>(),
            (acc, x) => {
                if (!acc.ContainsKey(x)) {
                    acc[x] = 0;
                } 
               
                acc[x]++;
                return acc;
            });
        
        return b.Aggregate(0, (acc, x) => {
            if (dictionary.ContainsKey(x) && dictionary[x] > 0) {
                dictionary[x]--;
                return acc;
            }
            
            return acc + 1;
        }) + dictionary.Aggregate(0, (acc, x) => acc + x.Value);
    }
    
    static void Main(String[] args) {
        Console.WriteLine(AnagramCount(Console.ReadLine(), Console.ReadLine()));
    }
}
