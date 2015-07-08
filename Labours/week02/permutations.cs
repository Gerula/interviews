using System;

static class Program {
    static void Permutations(this int[] a, int step) {
        if (step == a.Length) {
            Console.WriteLine(String.Join(", ", a));
            return;
        }

        for (int i = step; i < a.Length; i++) {
            a.Swap(i, step);
            Console.WriteLine("i = {0} step = {1} {2}", i, step, String.Join(", ", a));
            a.Permutations(step + 1);
            a.Swap(i, step);
        }
    }

    static void Swap(this int[] a, int i, int j) {
        int c = a[i]; a[i] = a[j]; a[j] = c;
    }

    static void Main() {
        int[] a = new int[] {1, 2, 3};
        a.Permutations(0);
    }
}
