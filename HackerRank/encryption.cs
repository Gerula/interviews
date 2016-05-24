//  https://www.hackerrank.com/challenges/encryption
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Solution {
    static String Encode(String s) {
        s = new String(s.Where(x => x != ' ').ToArray());
        var size = Math.Sqrt(s.Length);
        var low = (int) Math.Floor(size);
        var high = (int) Math.Ceiling(size);

        var min = int.MaxValue;
        var lines = 0; var columns = 0;
        for (var i = low; i <= high; i++) {
            for (var j = low; j <= high; j++) {
                if (i * j >= s.Length && i * j < min) {
                    min  = i * j;
                    lines = i;
                    columns = j;
                }
            }
        }
        
        var result = new StringBuilder(s.Length + columns);
        for (var j = 0; j < columns; j++) {
            for (var i = 0; i < lines; i++) {
                if (i * columns + j >= s.Length) {
                    break;
                }
                
                result.Append(s[i * columns + j]);
            }    
            
            result.Append(' ');
        }
        
        return result.ToString();
    }

    static void Main(String[] args) {
        Console.WriteLine(Encode(Console.ReadLine()));
    }
}

