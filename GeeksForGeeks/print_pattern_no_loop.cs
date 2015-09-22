// http://www.geeksforgeeks.org/print-a-pattern-without-using-any-loop/
//
//
// Print a pattern without using any loop
//
// Given a number n, print following pattern without using any loop.
//
// Input: n = 16
// Output: 16, 11, 6, 1, -4, 1, 6, 11, 16
//
// Input: n = 10
// Output: 10, 5, 0, 5, 10
//
using System;

class Program {
    static void Print(int i, int m, bool flag) {
        Console.Write("{0} ", i);
        if (i == m && !flag) {
            Console.WriteLine();
            return;
        }

        if (flag) {
            Print(i - 5, m, i - 5 > 0); 
        } else {
            Print(i + 5, m, false);
        }
    }

    static void Main() {
        Print(16, 16, true);
        Print(10, 10, true);
    }
}
