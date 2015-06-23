using System;

class Program {
    static void Permutations(int[] a, int step) {
        if (step == a.Length) {
            Console.WriteLine(String.Join(",", a));
        }
        
        for (int i = step; i < a.Length; i++) {
            swap(ref a[i], ref a[step]);
            Permutations(a, step + 1);
            swap(ref a[i], ref a[step]);
        }
    }

    static void swap(ref int a, ref int b) {
        int c = a;
        a = b;
        b = c;
    }

    static void Main() {
        int[] a = new int[] {1, 2, 3};
        Permutations(a, 0);
    }
}
