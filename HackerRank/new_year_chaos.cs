//  https://www.hackerrank.com/challenges/new-year-chaos?h_r=next-challenge&h_v=zen
//  3 out of 11 tests passed. Misleading first test.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static int Result;
    static String AlmostSort(int[] a) {
        if (a.Select((x, index) => x - index - 1).Any(x => x > 2)) {
            return "Too chaotic";
        }
        
        Sort(a);
        return Result.ToString();
    }
    
    static int[] Sort(int[] a) {
        if (a.Length < 2) {
            return a;
        }
        
        return Merge(
                  Sort(a.Take(a.Length / 2).ToArray()),
                  Sort(a.Skip(a.Length / 2).ToArray()));
    }
    
    static int[] Merge(int[] a, int[] b) {
        if (!a.Any()) {
            return b;
        }
        
        if (!b.Any()) {
            return a;
        }
        
        var c = new List<int>(a);
        foreach (var x in b) {
            c.Add(x);
            var i = c.Count - 1;
            while (i > 0 && c[i] < c[i - 1]) {
                var man = c[i]; c[i] = c[i - 1]; c[i - 1] = man;
                i--;
                Result++;
            }
        }
        
        return c.ToArray();
    }
    
    static void Main(String[] args) {
        int T = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < T; a0++){
            Console.ReadLine();
            string[] q_temp = Console.ReadLine().Split(' ');
            int[] q = Array.ConvertAll(q_temp,Int32.Parse);
            Console.WriteLine(AlmostSort(q));
        }
    }
}

