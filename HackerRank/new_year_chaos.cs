//  https://www.hackerrank.com/challenges/new-year-chaos?h_r=next-challenge&h_v=zen
//  1 out of 11 tests passed. Misleading first test.
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
        
        var c = new int[a.Length + b.Length];
        var i = 0;
        var j = 0;
        var k = 0;
        while (i < a.Length && j < b.Length) {
            if (a[i] > b[j]) {
                c[k++] = b[j];
                Result++;
                j++;
            } else {
                c[k++] = a[i];
                i++;
            }
        }
        
        for (var l = i; l < a.Length; l++) {
            c[k++] = a[l];    
        }
        
        for (var l = j; l < b.Length; l++) {
            c[k++] = b[l];    
        }
        
        return c;
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

