//  https://www.hackerrank.com/challenges/new-year-chaos?h_r=next-challenge&h_v=zen
//  1 out of 11 tests passed. Misleading first test.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static String AlmostSort(int[] a) {
        var bribes = 0;
        for (var i = 0; i < a.Length; i++) {
            while (a[i] != i + 1) {
                var target = a[i] - 1;
                if (Math.Abs(target - i) > 2) {
                    return "Too chaotic"; 
                }

                var c = a[target];
                a[target] = a[i];
                a[i] = c;
                bribes++;
            }
        }
        
        return bribes.ToString();
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

