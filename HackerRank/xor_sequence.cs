//  https://www.hackerrank.com/challenges/xor-se
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static long Sequence(long L, long R) {
        long start = 0;
        
        switch((L - 1) % 4) {
            case 0 : start = L - 1; break;
            case 1 : start = 1; break;
            case 2 : start = L; break;
            case 3 : start = 0; break;
        }
               
        long result = 0;
        for (var x = L; x <= R; x++) {
            start ^= x;
            result ^= start;
        }
        
        return result;
    }
    //  A(0) = 0        = 0
    //  A(1) = 1 ^ 0    = 1
    //  A(2) = 1 ^ 2    = 3
    //  A(3) = 3 ^ 3    = 0
    //  A(4) = 0 ^ 4    = 4
    //  A(5) = 4 ^ 5    = 1
    //  A(6) = 6 ^ 1    = 7
    //  A(7) = 7 ^ 7    = 0
    //  A(8) = 8 ^ 0    = 8
    //  A(9) = 9 ^ 8    = 1
    // A(10) = 10 ^ 1   = 11
    // A(11) = 11 ^ 11  = 0
    // A(12) = 12 ^ 0   = 12
    // A(13) = 13 ^ 12  = 1
    // A(14) = 14 ^ 1   = 15
    // A(15) = 15 ^ 15  = 0
    
    static void Main(String[] args) {
        int Q = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < Q; a0++){
            string[] tokens_L = Console.ReadLine().Split(' ');
            long L = Convert.ToInt64(tokens_L[0]);
            long R = Convert.ToInt64(tokens_L[1]);
            Console.WriteLine(Sequence(L, R));
        }
    }
}

