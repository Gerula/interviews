//  https://www.hackerrank.com/challenges/two-strings
//  You are given two strings, and . Find if there is a substring that appears in both and .
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static HashSet<char> ToHash(String a) {
        return a.Aggregate(new HashSet<char>(), (acc, x) => {
            acc.Add(x);
            return acc;
        });
    }
    static bool IsCommon(String s, String t) {
        return ToHash(s).Intersect(ToHash(t)).Any();
    }

    static void Main(String[] args) {
        var n = int.Parse(Console.ReadLine());
        for (var i = 0; i < n; i++) {
            Console.WriteLine(IsCommon(Console.ReadLine(), Console.ReadLine()) ? "YES" : "NO");
        }
    }
}
