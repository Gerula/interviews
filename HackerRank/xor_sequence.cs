//  https://www.hackerrank.com/challenges/xor-se
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static long GetSequenceAt(long x) {
        switch(x % 4) {
            case 0 : return x; 
            case 1 : return 1; 
            case 2 : return x + 1; 
            case 3 : return 0;
        }
        
        return 0;
    }
    
    static long GetSequenceUntil(long x) {
        var k = GetSequenceAt(x / 2);
        if (x % 2 == 0) {
            return 2 * k;
        }
        
        return 2 * k + (1 - (x / 2) % 2);
    }
    
    static long Sequence(long L, long R) {
        return GetSequenceUntil(L - 1) ^ GetSequenceUntil(R);
    }
    
    //  A(0) = 0        = 0 - 0 
    //  A(1) = 1 ^ 0    = 1 - 1
    //  A(2) = 2 ^ 1    = 3 - 2
    //  A(3) = 3 ^ 3    = 0 - 2
    //  A(4) = 4 ^ 0    = 4 - 6
    //  A(5) = 5 ^ 4    = 1 - 7
    //  A(6) = 6 ^ 1    = 7 - 0
    //  A(7) = 7 ^ 7    = 0 - 0
    //  A(8) = 8 ^ 0    = 8 - 8
    //  A(9) = 9 ^ 8    = 1 - 9
    // A(10) = 10 ^ 1   = 11 - 2
    // A(11) = 11 ^ 11  = 0 - 2
    // A(12) = 12 ^ 0   = 12 - 14
    // A(13) = 13 ^ 12  = 1 - 15
    // A(14) = 14 ^ 1   = 15 - 0
    // A(15) = 15 ^ 15  = 0 - 0
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

