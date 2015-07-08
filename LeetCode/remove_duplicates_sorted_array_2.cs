using System;
using System.Linq;
using System.Collections.Generic;

static class Program {
    static int RemoveDupes(this int[] a) {
        int write = 1;
        int read = 1;
        bool same = false;
        int count = 0;
        
        while (read < a.Length) {
            if (same && (a[read] == a[read - 1])) {
                count++;
            } else {
                same = a[read] == a[read - 1];
                a[write++] = a[read];
            }
            read++;
        }

        return a.Length - count;
    }

    static int[] RemoveDupes2(this int[] v) {
        return v.Aggregate(new List<int>(),
                           (a, b) => {
                                if (a.Count(x => x == b) < 2) {
                                    a.Add(b);
                                }

                                return a;
                           }).ToArray();
    }

    static void Main() {
        int[] a = new int[] {1, 1, 1, 2, 2, 3, 3, 3};
        int c = RemoveDupes(a);
        for (int i = 0; i < c; i++) {
            Console.Write("{0} ", a[i]);
        }

        Console.WriteLine();

        foreach (int x in RemoveDupes2(a)) {
            Console.Write("{0} ", x);
        }

        Console.WriteLine();
    }
}
