//  https://www.hackerrank.com/challenges/candies
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static int Candies(int[] a) {
        if (a.Length <= 1) {
            return a.Length;
        }
        
        var candies = Enumerable.Repeat(1, a.Length).ToArray();
        
        for (var i = 1; i < a.Length; i++) {
            if (a[i] > a[i - 1] && candies[i] <= candies[i - 1]) {
                candies[i] = candies[i - 1] + 1;
            }
        }
        
        for (var i = a.Length - 2; i >= 0; i--) {
            if (a[i] > a[i + 1] && candies[i] <= candies[i + 1]) {
                candies[i] = candies[i + 1] + 1;
            }
        }
        
        return candies.Sum();
    }
    
    static void Main(String[] args) {
        var n = int.Parse(Console.ReadLine());
        var a = new int[n];
        for (var i = 0; i < n; i++) {
            a[i] = int.Parse(Console.ReadLine());
        }
        
        Console.WriteLine(Candies(a));
    }
}
