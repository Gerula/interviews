using System;

static class Program {
    static int RemoveDupes(this int[] a) {
        int write = 1;
        int read = 0;
        bool same = false;
        int count = 0;
        
        for (int i = 1; i < a.Length; i++) {
            read = i;
            if (same && a[read] == a[write]) {
                count++;
                continue;
            }

            same = a[read] == a[write];
            a[write++] = a[read];
        }

        return a.Length - count;
    }

    static void Main() {
        int[] a = new int[] {1, 1, 1, 2, 2, 3, 3, 3};
        int c = RemoveDupes(a);
        for (int i = 0; i < c; i++) {
            Console.Write("{0} ", a[i]);
        }

        Console.WriteLine();
    }
}
