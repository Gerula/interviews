//  Wow, these ARE harder.
//  https://www.hackerrank.com/challenges/cipher
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Solution {
    static String Recover(int n, int k, String s) {
        var result = new int[n];
        var mask = 0;
        for (var i = 0; i < n; i++) {
            result[i] ^= mask ^ s[i] - '0';
            mask ^= result[i];
            if (i >= k - 1) {
                mask ^= result[i - k + 1]; 
            }
        }
        
        return String.Join(String.Empty, result.Select(x => x.ToString()));
    }
    //   1001010
    //    1001010
    //     1001010
    //      1001010
    // ----------
    //   1110100110
    // 0 - bit 0
    // 1 - bit 1 ^ bit 0
    // 2 - bit 2 ^ bit 1 ^ bit 0            == bit_2 ^ bit 1
    // 3 - bit 3 ^ bit 2 ^ bit 1 ^ bit 0    == bit_3 ^ bit 2
    // 4 - bit 4 ^ bit 3 ^ bit 2 ^ bit 1    == bit_4 ^ bit 3 ^ bit 0 
    // 5 - bit 5 ^ bit 4 ^ bit 3 ^ bit 2    == bit_5 ^ bit 4 ^ bit 1
    // 6 - bit 6 ^ bit 5 ^ bit 4 ^ bit 3    == bit_6 ^ bit 5 ^ bit 2
    // 7 - bit 6 ^ bit 5 ^ bit 4            == bit 6 ^ bit 3
    // 8 - bit 6 ^ bit 5                    == bit 6 ^ bit 5
    // 9 - bit 6                            == bit_6
    static void Main(String[] args) {
        var input = Console.ReadLine().Split();
        var x = int.Parse(input[0]);
        var k = int.Parse(input[1]);
        var s = Console.ReadLine();
        Console.WriteLine(Recover(x, k, s), 2);
    }
}
