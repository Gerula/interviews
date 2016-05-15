//  https://www.hackerrank.com/challenges/flipping-bits
using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        var count = int.Parse(Console.ReadLine());
        for (var i = 0; i < count; i++) {
            Console.WriteLine(UInt32.Parse(Console.ReadLine()) ^ UInt32.MaxValue);
        }
    }
}
