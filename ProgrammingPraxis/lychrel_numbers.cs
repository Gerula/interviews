using System;
using System.Collections.Generic;

class Program {
    static HashSet<long> lychrels = new HashSet<long>();

    static bool IsPalindrome(long x) {
        return x == Reverse(x);
    }

    static long Reverse(long x) {
        long result = 0;
        while (x > 0) {
            result = result * 10 + x % 10;
            x /= 10;
        }

        return result;
    }

    static bool IsLychrel(int x) {
        long n = x;
        while (n < Int32.MaxValue) {
            n = n + Reverse(n);
            if (lychrels.Contains(n) || IsPalindrome(n)) {
                lychrels.Add(n);
                return true;
            }
        }
        
        return false;
    }

    static void Main() {
        for (int i = 1; i < 300; i++) {
            Console.Write("[{0} : {1}] ", i, IsLychrel(i));
        }

        Console.WriteLine();
    }
}
