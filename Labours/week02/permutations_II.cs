using System;

static class Program {
    static void Permutations(this int[] a, int step) {
        if (step == a.Length) {
            Console.WriteLine(String.Join(", ", a));
            return;
        }

        for (int i = step; i < a.Length; i++) {
            if (a[i] != a[step] || i == step) {
                a.Swap(i, step);
                a.Permutations(step + 1);
                a.Swap(i, step);
            }
        }
    }

    static void Swap(this int[] a, int i, int j) {
        int c = a[i]; a[i] = a[j]; a[j] = c;
    }

    static void Main() {
        int[] a = new int[] {1, 1, 2};
        a.Permutations(0);
    }
}
