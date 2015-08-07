using System;

class Program {
    static void Main() {
        int[] a = new int[] {3, 2, 1, 3, 6, 5};
        for (int i = 0; i < a.Length; i++) {
            int current = i;
            while (current < a.Length && a[current] != current + 1 && a[current] != a[a[current] - 1]) {
                int next = a[current] - 1;
                int aux = a[next];
                a[next] = a[current];
                a[current] = aux;
                current = next;
            }
        }

        for (int i = 0; i < a.Length; i++) {
            if (a[i] != i + 1) {
                Console.WriteLine("missing {0} dup {1}", i + 1, a[i]);
                return;
            }
        }

        Console.WriteLine("None");
    }
}
