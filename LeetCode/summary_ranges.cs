using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main() {
        int[] a = new int[] {0, 1, 2, 4, 5, 7};
        int start = 0;
        int end = 0;
        for (int i = 1; i < a.Length + 1; i++) {
            if (i < a.Length && a[i] - a[i - 1] == 1) { 
                end++;
            } else {
                if (end == start) {
                    Console.Write("[{0}]", a[start]);
                } else {
                    Console.Write("[{0} => {1}]", a[start], a[end]);
                }

                start = i;
                end = i;
            }
        }

        Console.WriteLine();
    }
}
