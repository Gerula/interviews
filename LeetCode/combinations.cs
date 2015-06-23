using System;

class Program {

    static void Combinations(int n, int k, int index, int step, int[] result) {
        if (step == k) {
            Console.WriteLine(String.Join(",", result));
            return;
        }

        for (int i = index; i <= n; i++)
        {
            result[step] = i;
            Combinations(n, k, i + 1, step + 1, result);
        }
    }

    static void Main() {
        Combinations(4, 2, 1, 0, new int[2]);
    }
}
