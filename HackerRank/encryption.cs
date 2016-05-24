//  https://www.hackerrank.com/challenges/encryption
//  Need to come up with a more elegant solution that actually building the array i.e. virtualizing indexes
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Solution {
    static String Encode(String s) {
        var sb = new StringBuilder(new String(s.Where(x => x != ' ').ToArray()));
        var size = Math.Sqrt(sb.Length);
        var low = (int) Math.Floor(size);
        var high = (int) Math.Ceiling(size);

        var min = int.MaxValue;
        var lines = 0; var columns = 0;
        for (var i = low; i <= high; i++) {
            for (var j = low; j <= high; j++) {
                if (i * j >= sb.Length && i * j < min) {
                    min  = i * j;
                    lines = i;
                    columns = j;
                }
            }
        }

        var array = new char[lines, columns];
        var k = 0;
        for (var i = 0; i < lines && k < sb.Length; i++) {
            for (var j = 0; j < columns && k < sb.Length; j++) {
                array[i, j] = sb[k++];
            }
        }
        
        sb.Length = 0;
        for (var j = 0; j < columns; j++) {
            for (var i = 0; i < lines; i++) {
                if (array[i, j] == 0) {
                    break;
                }
                
                sb.Append(array[i, j]);
            }

            sb.Append(' ');
        }
        
        return sb.ToString();
    }

    static void Main(String[] args) {
        Console.WriteLine(Encode(Console.ReadLine()));
    }
}

