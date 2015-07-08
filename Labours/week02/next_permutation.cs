using System;
using System.Linq;

static class Program {
    static int[] Next(this int[] a) {
        int k = -1;
        for (int i = 0; i < a.Length - 1; i++) {
            if (a[i] < a[i + 1]) {
                k = i;
            }
        }

        if (k == -1) {
            return a.OrderBy(x => x).ToArray();
        }

        int l = k;
        for (int i = k; i < a.Length; i++) {
            if (a[i] > a[k]) {
                l = i;
            }
        }

        int c = a[k];
        a[k] = a[l];
        a[l] = c;

        for (int i = k + 1; i < k + 1 + (a.Length - k - 1) / 2; i++) {
            c = a[i];
            a[i] = a[a.Length - i - 1];
            a[a.Length - 1 - 1] = c;
        }

        return a;
    } 

    static void Main() {
        Console.WriteLine(String.Join(", ", new int[] {3, 2, 1}.Next()));    
    }
}
