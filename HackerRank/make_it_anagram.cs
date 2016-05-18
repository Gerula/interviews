//  https://www.hackerrank.com/challenges/make-it-anagram

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static int AnagramCount(String a, String b) {
        var firstSet = new HashSet<char>(a);
        var secondSet = new HashSet<char>(b);
        return firstSet.Union(secondSet).Except(firstSet.Intersect(secondSet)).Count();
    }
    
    static void Main(String[] args) {
        Console.WriteLine(AnagramCount(Console.ReadLine(), Console.ReadLine()));
    }
}
