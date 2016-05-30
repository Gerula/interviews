//  https://www.hackerrank.com/challenges/morgan-and-a-string
//
//  Misleading example (1/18 pass)
using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static String Morgan(String a, String b) {
        if (String.IsNullOrEmpty(a)) {
            return b;
        }
        
        if (String.IsNullOrEmpty(b)) {
            return a;
        }
        
        return (a[0] < b[0]) ? 
                     a[0] + Morgan(a.Substring(1), b):
                     b[0] + Morgan(a, b.Substring(1));
    }
    
    static void Main(String[] args) {
        var n = int.Parse(Console.ReadLine());
        for (var i = 0; i < n; i++) {
            Console.WriteLine(Morgan(Console.ReadLine(), Console.ReadLine()));
        }
    }
}
